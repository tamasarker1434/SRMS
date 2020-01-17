using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace SRMS.App_Code.DBUtility
{
    public class PrintHelper
    {
        public void ExportToPDF(string reportContent, string reportName, int left = 20, int right = 20, int top = 20, int botton = 30, bool isLendscape = false)
        {
            try
            {
                Document doc = new Document(PageSize.A4, left, right, top, botton);
                
                reportName = reportName + ".pdf";
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("content-disposition",
                 "attachment;filename=" + reportName + "");
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                string html = reportContent;
                html = Regex.Replace(html, "</?(a|A).*?>", "");


                PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                //writer.PageEvent = new ITextEvents();
                doc.Open();
                doc.NewPage();
                // CSS
                var cssResolver = new StyleAttrCSSResolver();
                //var cssFile = XMLWorkerHelper.GetCSS(new FileStream(HttpContext.Current.Server.MapPath("~/Content/resume.css"), FileMode.Open));
                var cssFile = XMLWorkerHelper.GetCSS(new FileStream(HttpContext.Current.Server.MapPath("~/Content/bootstrap.css"), FileMode.Open));
                cssResolver.AddCss(cssFile);

                // HTML
                CssAppliers ca = new CssAppliersImpl();
                HtmlPipelineContext hpc = new HtmlPipelineContext(ca);
                hpc.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

                // PIPELINES
                PdfWriterPipeline pdf = new PdfWriterPipeline(doc, writer);
                //PdfWriterPipeline pdf = new PdfWriterPipeline(doc, writer);
                HtmlPipeline htmlPipe = new HtmlPipeline(hpc, pdf);
                CssResolverPipeline css = new CssResolverPipeline(cssResolver, htmlPipe);

                XMLWorker worker = new XMLWorker(css, true);
                XMLParser p = new XMLParser(worker);
                StringReader sr = new StringReader(html);
                p.Parse(sr);
                doc.Close();
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }
        }
    }
}
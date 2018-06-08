using System;
using System.IO;
using NAA.Shared.Model;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace NAA.Service
{
    public class PdfGenerator
    {
        public string GeneratePdf(Application application, out string title)
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var filename = $"pdfs{Path.DirectorySeparatorChar}{application.ApplicantId}.pdf";
            var path = Path.Combine(home, filename);

            title = $"Application {application.University} - {application.CourseName}.pdf";

            var document = DoGenerate(application, title);

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            document.Save(path);

            return path;
        }

        private PdfDocument DoGenerate(Application application, string title)
        {
            var document = new PdfDocument();
            document.Info.Title = title;

            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Fonts
            var h1 = new XFont("Verdana", 40, XFontStyle.BoldItalic);
            var h2 = new XFont("Verdana", 30, XFontStyle.BoldItalic);
            var bold = new XFont("Verdana", 12, XFontStyle.Bold);
            var normal = new XFont("Verdana", 12);

            // Constans
            const int itemXpos = 190;
            const int itemLableXPos = 100;

            // Draw the text
            gfx.DrawString("NAA", h1, XBrushes.Black, new XRect(0, 60, page.Width, page.Height),
                XStringFormats.TopCenter);

            gfx.DrawString("Application Certificate", h2, XBrushes.Black, new XRect(0, 120, page.Width, page.Height),
                XStringFormats.TopCenter);

            gfx.DrawString("Name", bold, XBrushes.Black, new XRect(itemLableXPos, 200, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString(application.Applicant.Name, normal, XBrushes.Black,
                new XRect(itemXpos, 200, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("University", bold, XBrushes.Black, new XRect(itemLableXPos, 230, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString(application.University, normal, XBrushes.Black,
                new XRect(itemXpos, 230, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Course", bold, XBrushes.Black, new XRect(itemLableXPos, 260, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString(application.CourseName, normal, XBrushes.Black,
                new XRect(itemXpos, 260, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Status", bold, XBrushes.Black, new XRect(itemLableXPos, 290, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString(application.OfferState.ToString(), normal, XBrushes.Black,
                new XRect(itemXpos, 290, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawString("Firm", bold, XBrushes.Black, new XRect(itemLableXPos, 320, page.Width, page.Height),
                XStringFormats.TopLeft);
            gfx.DrawString(application.Confirmed ? "Yes" : "No", normal, XBrushes.Black,
                new XRect(itemXpos, 320, page.Width, page.Height), XStringFormats.TopLeft);

            return document;
        }
    }
}
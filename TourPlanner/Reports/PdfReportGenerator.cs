using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DataAccessLayer;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using Models;
using Paragraph = iText.Layout.Element.Paragraph;

namespace TourPlanner.Reports {
    public class PdfReportGenerator { 

        private string dirPath;

        public PdfReportGenerator() {
            var config = new ConfigurationController();
            dirPath = config.ReportsPath;
        }
        public bool GenerateReport(Tour tour, List<TourLog> logs) {
            string filename =
                $"{dirPath}{Regex.Replace(tour.name, @"\s+", "")}_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}_Report.pdf";
            Document pdfDoc = new Document(new PdfDocument(new PdfWriter(filename)));

            pdfDoc
                .Add(new Paragraph($"Report for Tour: {tour.name}")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(15)
                    .SetMarginBottom(20))
                .Add(new Paragraph($"Description: {tour.description}")
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                    .SetMarginBottom(10))
                .Add(new Paragraph($"Start: {tour.from}")
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                    .SetMarginBottom(5))
                .Add(new Paragraph($"End: {tour.to}")
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                    .SetMarginBottom(20))
                .Add(new Paragraph($"Distance: {tour.distance}")
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                    .SetMarginBottom(10))
                .Add(new Paragraph("Logs:")
                    .SetMarginBottom(3));

            int counter = 1;

            foreach (TourLog tourLog in logs) {
                pdfDoc.Add(new Paragraph(
                    $"{counter}. Tour: {tour.name} Date: {tourLog.date} (Rating: {tourLog.rating}): " +
                    $"{tourLog.distance}km in {tourLog.duration} with an average speed of {tourLog.avgSpeed}km/h."));
                counter++;
            }
            System.Diagnostics.Process.Start(filename);
            pdfDoc.Close();

            return true;
        }

        public bool GenerateSummaryReport(string tourName, List<TourLog> logs) {
            string filename =
                $"{dirPath}{Regex.Replace(tourName, @"\s+", "")}_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}_StatisticReport.pdf";
            Document document = new Document(new PdfDocument(new PdfWriter(filename)));
            Dictionary<string, double> sums = new Dictionary<string, double> {
                ["distance"] = 0, ["time"] = 0, ["count"] = 0
            };
            logs.ForEach((log) => {
                sums["count"]++;
                sums["distance"] += Convert.ToDouble(log.distance);
                TimeSpan time = TimeSpan.Parse(log.duration);
                sums["time"] += time.Ticks;
            });

            document
                .Add(new Paragraph($"Statistic Report for Tour: {tourName}")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20)
                    .SetMarginBottom(20))
                .Add(new Paragraph($"Logs: {logs.Count}\nTotal Distance: {sums["distance"]} km\nTotal Time: {new TimeSpan((long)sums["time"]):g}")
                    .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                    .SetMarginBottom(10))
                .Add(new Paragraph("Logs:")
                    .SetMarginBottom(3));

            int counter = 1;

            foreach (TourLog tourLog in logs) {
                document.Add(new Paragraph(
                    $"{counter}. Date: {tourLog.date} Rating: {tourLog.rating}): " +
                    $"{tourLog.distance}km in {tourLog.duration} with an average speed of {tourLog.avgSpeed}km/h."));
                counter++;
            }
            System.Diagnostics.Process.Start(filename);
            document.Close();

            return true;
        }
    }
}

using System;
using System.IO;

using AppKit;
using Foundation;
using PdfKit;

namespace DocumentFiler
{
    public partial class ViewController : NSViewController
    {
        private const string __source_path = "/Volumes/Ben/Dropbox-ScanSnap/Scansnap";
        private const string __dest_path = "/Users/b/Documents/Paper";
        private const string __pgi_receipt_path = "/Users/b/Documents/Receipts/PGi";
        private string _source_file = "";
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            cboCategory.SelectionChanged += cboCategory_SelectionChanged;
            cboFile.SelectionChanged += cboFile_SelectionChanged;
            cboMonth.SelectionChanged += cboMonth_SelectionChanged;
            cboYear.SelectionChanged += cboYear_SelectionChanged;
            cboVendor.SelectionChanged += cboVendor_SelectionChanged;

            Refresh(null);
        }

        partial void Refresh(NSObject sender)
        {
            imgPDF.Document = null;
            cboCategory.DeselectItem(0);
            cboCategory.Enabled = false;
            cboFile.DeselectItem(0);
            cboFile.Enabled = false;
            cboMonth.DeselectItem(0);
            cboMonth.Enabled = false;
            cboYear.DeselectItem(0);
            cboYear.Enabled = false;
            cboVendor.DeselectItem(0);
            cboVendor.Enabled = false;
            txtFilename.StringValue = "";
            btnFileAndRefresh.Enabled = false;

            var fileList = Directory.GetFiles(__source_path, "*.pdf");

            if (fileList.Length > 0)
            {
                cboCategory.Enabled = true;
                if (fileList.Length == 1)
                {
                    lblRemainingWork.StringValue = $"Categorizing {fileList.Length} file";
                }
                else
                {
                    lblRemainingWork.StringValue = $"Categorizing {fileList.Length} files";
                }
                _source_file = fileList[0];
                var docUrl = new NSUrl(_source_file, false);
                imgPDF.Document = new PdfDocument(docUrl);
                imgPDF.AutoScales = true;
                imgPDF.DisplayDirection = PdfDisplayDirection.Horizontal;
                imgPDF.DisplayMode = PdfDisplayMode.SinglePage;
            }
            else
            {
                lblRemainingWork.StringValue = "Waiting for files";
            }
        }

        protected void cboCategory_SelectionChanged(object sender, EventArgs args)
        {
            if (cboCategory.SelectedIndex > 0)
            {
                cboFile.Enabled = true;
            }

            txtFilename.StringValue = BuildFilename();
        }

        protected void cboFile_SelectionChanged(object sender, EventArgs args)
        {
            if (cboFile.SelectedIndex > 0)
            {
                cboMonth.Enabled = true;
            }

            txtFilename.StringValue = BuildFilename();
        }

        protected void cboMonth_SelectionChanged(object sender, EventArgs args)
        {
            if (cboMonth.SelectedIndex > 0)
            {
                cboYear.Enabled = true;
            }

            txtFilename.StringValue = BuildFilename();
        }

        protected void cboYear_SelectionChanged(object sender, EventArgs args)
        {
            if (cboYear.SelectedIndex > 0)
            {
                cboVendor.Enabled = true;
            }

            txtFilename.StringValue = BuildFilename();
        }

        protected void cboVendor_SelectionChanged(object sender, EventArgs args)
        {
            if (cboVendor.SelectedIndex > 0)
            {
                btnFileAndRefresh.Enabled = true;
            }

            txtFilename.StringValue = BuildFilename();
        }

        partial void FileDocument(NSObject sender)
        {        
            var dest_file = "";
            if (cboCategory.SelectedIndex == 0)
            {
                dest_file = __pgi_receipt_path + "/" + BuildFilename();
            } else
            {
                dest_file = __dest_path + "/" + BuildFilename();
            }

            Directory.CreateDirectory(Path.GetDirectoryName(dest_file));

            File.Move(_source_file, dest_file);

            Refresh(sender);
        }

        partial void Discard(NSObject sender)
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "Are you sure you want to discard this can?",
                MessageText = "Confirm discard",
            };

            alert.AddButton("Ok");
            alert.AddButton("Cancel");
            var result = alert.RunModal();

            if (result == 1000)
            {
                File.Delete(_source_file);
                Refresh(sender);
            }
        }
        private string BuildFilename()
        {
            var category = "";
            var file = "{file}";
            var month = "{month}";
            var year = "{year}";
            var vendor = "{vendor}";

            btnFileAndRefresh.Enabled = false;
            switch (cboCategory.SelectedValue.ToString())
            {
                case "PGi Expense":
                    btnFileAndRefresh.Enabled = true;
                    return $"{DateTime.Now:yyyyMMdd-Hmmss}.pdf";
                    
                default:
                    category = cboCategory.SelectedValue.ToString();
                    cboFile.Enabled = true;
                    break;
            }

            
            if (cboFile.SelectedIndex > -1)
            {
                file = cboFile.SelectedValue.ToString();
                cboMonth.Enabled = true;
            }

            if (cboMonth.SelectedIndex > -1)
            {
                month = $"{cboMonth.SelectedIndex + 1}";
                cboYear.Enabled = true;
            }

            if (cboYear.SelectedIndex > -1)
            {
                year = cboYear.SelectedValue.ToString();
                cboVendor.Enabled = true;
            }

            if (cboVendor.SelectedIndex > -1)
            {
                vendor = cboVendor.SelectedValue.ToString();
                btnFileAndRefresh.Enabled = true;
            }

            return $"{file}/{year}/{category}/{month}/{vendor}-{DateTime.Now:yyyyMMdd-Hmmss}.pdf";
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }        
    }
}

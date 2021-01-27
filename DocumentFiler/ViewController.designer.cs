// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DocumentFiler
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton btnFileAndRefresh { get; set; }

		[Outlet]
		AppKit.NSButton btnRefresh { get; set; }

		[Outlet]
		AppKit.NSComboBox cboCategory { get; set; }

		[Outlet]
		AppKit.NSComboBox cboFile { get; set; }

		[Outlet]
		AppKit.NSComboBox cboMonth { get; set; }

		[Outlet]
		AppKit.NSComboBox cboVendor { get; set; }

		[Outlet]
		AppKit.NSComboBox cboYear { get; set; }

		[Outlet]
		PdfKit.PdfView imgPDF { get; set; }

		[Outlet]
		AppKit.NSTextField lblRemainingWork { get; set; }

		[Outlet]
		AppKit.NSTextField txtFilename { get; set; }

		[Action ("Discard:")]
		partial void Discard (Foundation.NSObject sender);

		[Action ("FileDocument:")]
		partial void FileDocument (Foundation.NSObject sender);

		[Action ("Refresh:")]
		partial void Refresh (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnFileAndRefresh != null) {
				btnFileAndRefresh.Dispose ();
				btnFileAndRefresh = null;
			}

			if (btnRefresh != null) {
				btnRefresh.Dispose ();
				btnRefresh = null;
			}

			if (cboCategory != null) {
				cboCategory.Dispose ();
				cboCategory = null;
			}

			if (cboFile != null) {
				cboFile.Dispose ();
				cboFile = null;
			}

			if (cboMonth != null) {
				cboMonth.Dispose ();
				cboMonth = null;
			}

			if (cboVendor != null) {
				cboVendor.Dispose ();
				cboVendor = null;
			}

			if (cboYear != null) {
				cboYear.Dispose ();
				cboYear = null;
			}

			if (imgPDF != null) {
				imgPDF.Dispose ();
				imgPDF = null;
			}

			if (lblRemainingWork != null) {
				lblRemainingWork.Dispose ();
				lblRemainingWork = null;
			}

			if (txtFilename != null) {
				txtFilename.Dispose ();
				txtFilename = null;
			}
		}
	}
}

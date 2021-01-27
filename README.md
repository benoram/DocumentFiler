# DocumentFiler
A simple Mac app that takes files from dropbox and prompts me on how to file them. I use this to process scans from ScanSnap Cloud

This was my first Mac app, built with Xamarin using Visual Studio.app. This is written just for me to fill a very specific need of processing scans. Ultimately my preference is to keep ScanSnap and Dropbox software off of my local machine. And I only scan important mail, so only a couple dozen docs p/month go through this process.

## Workflow

My scanning workflow is as follows.

1. I have a ScanSnap iX100. This scanner was configured on my wireless device with ScanSnap Cloud.

2. ScanSnap Cloud takes all documents from the device, applies OCR, and converts to searchable PDF

3. ScanSnap Cloud writes files to Dropbox.

3b. My Synology is configured to Dropbox to a folder

3c. My Mac has the Synology dropbox mirror volume connected over SMB

4. The app will sequentially open scans from the dropbox mirror and prompt me for how to file the document.

5. Based on how I answer prompts, the app will move the file from the mirror to long-term storage in my Documents folder.

6. Documents are backed up to iCloud and Backblaze.

## Finally

Like I said a very specific workflow :)
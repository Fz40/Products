	Dim Session As New NotesSession ,db As NotesDatabase
	Dim sourceview As NotesView,sourcedoc As NotesDocument
	Dim dataview As NotesView, dc As NotesDocumentCollection
	Dim datadoc As NotesDocument, maxcols As Integer
	Dim WS As New Notesuiworkspace
	Dim ViewString As String, Scope As String, GetField As Variant
	Dim C As NotesViewColumn, FieldName As String, K As Integer,N As Integer
	Dim xlApp As Variant, xlsheet As Variant, rows As Integer, cols As Integer
	Dim nitem As NotesItem , entry As NotesViewEntry, vwNav As NotesViewNavigator
	Dim ShowView()  As Variant, i As Integer, VList As Variant, ColVals As Variant
	
	Set db = session.CurrentDatabase   'link to current database
	

	'viewstring= ws.Prompt(PROMPT_OKCANCELLIST,"List of Views","Choose a View","",ShowView )
	'ใส่ชื่อ view ที่ต้องการเอาไปออก excel หรือ  csv
	ViewString ="PaymentDate"
	'เช็คว่ามีชื่อ view หรือไม่
	If Len(viewstring)=0 Then Exit Sub
	'ViewString ="Dan's View"
	
	'ดึงค่า view ที่ต้องการมาใสใน dataview
	Set dataview = db.getview(ViewString)  'get selected view
	
	Set vwnav= dataview.createViewnav()
	
	rows = 1
	cols = 1
	maxcols=dataview.ColumnCount  'how many columns?
	'Kill("d:\Book1.xlsx")
	Dim File_Name As String 
	'ตั้งชื่อ file ที่ต้องการ
	File_Name = "d:\Book1.csv"
	'เช็คว่ามี file ตาม  path นั้นไหม
	FileExists = (Dir(File_Name) <> "")
	If FileExists Then 'See above          
      ' First remove readonly attribute, if set
	  'ถ้ามีให้ใส่ แอดทิบิวเป็น อ่านอย่างเดียว เพื่อป้องกันการแก้ไข จะทำให้ลบไม่ได้
		Setattr File_Name, vbNormal          
      ' Then delete the file
	  ' ถ้ามีให้ทำการ ลบออก
		Kill File_Name
	End If
	'กำหนดค่าตัวแปรให้เป็น excel
	Set xlApp = CreateObject("Excel.Application")  
	'start Excel with OLE Automation
	xlApp.StatusBar = "Creating WorkSheet. Please be patient..."
	xlApp.Visible = False
	xlApp.Workbooks.Add
	xlApp.ReferenceStyle = 2
	Set xlsheet = xlApp.Workbooks(1).Worksheets(1)  
	'select first worksheet
	
	'worksheet title
	xlsheet.Cells(rows,cols).Value ="View: " + ViewString + ", from Database: " +  db.title +",  Extract created on: " +  Format(Now,"mm/dd/yyyy HH:MM")
	
	xlApp.StatusBar = "Creating Column Heading. Please be patient..."
	
	rows=2  'column headings starts in row 2
	For K=1 To maxcols
		Set c=dataview.columns(K-1)
		xlsheet.Cells(rows,cols).Value = c.title
		cols = cols + 1
	Next K
	
	Set entry=vwnav.GetFirstDocument
	rows=3   'data starts in third row
	Do While Not (entry Is Nothing)
		
		For cols=1 To maxcols 
			colvals=entry.ColumnValues(cols-1) 'subscript =0
			scope=Typename(colvals)
			Select Case scope
			Case "STRING"
				xlsheet.Cells(rows,cols).Value ="'" +  colvals
			Case Else 
				xlsheet.Cells(rows,cols).Value = colvals
			End Select   
		Next cols  
		xlApp.StatusBar = "Importing Notes Data   -   Document " & rows-1 '& " of " & dc.count & "."  
		rows=rows+1
		Set entry = vwnav.getnextdocument(entry)  
	Loop
	
	xlApp.Rows("1:1").Select
	xlApp.Selection.Font.Bold = True
	xlApp.Selection.Font.Underline = True
	xlApp.Range(xlsheet.Cells(2,1), xlsheet.Cells(rows,maxcols)).Select
	xlApp.Selection.Font.Name = "Arial"
	xlApp.Selection.Font.Size = 9
	xlApp.Selection.Columns.AutoFit
	With xlApp.Worksheets(1)
		.PageSetup.Orientation = 2
		.PageSetup.centerheader = "Report - Confidential"
		.Pagesetup.RightFooter = "Page &P" & Chr$(13) & "Date: &D"
		.Pagesetup.CenterFooter = ""
	End With
	xlApp.ReferenceStyle = 1
	xlApp.Range("A1").Select
	xlApp.StatusBar = "Importing Data from Lotus Notes Application was Completed."
	'xlapp.ActiveWorkbook.saveas "c:\VX" + Trim(Format(Now,"yyy"))   'save with generated name
	xlApp.ActiveWorkbook.saveas File_Name
	xlApp.Application.Quit
	dataview.clear 
	
	Set xlapp=Nothing   'stop OLE
	Set db=Nothing
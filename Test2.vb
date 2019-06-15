	Dim Session As New NotesSession ,db As NotesDatabase
	Dim sourceview As NotesView,sourcedoc As NotesDocument
	Dim dataview As NotesView, dc As NotesDocumentCollection
	Dim datadoc As NotesDocument, maxcols As Integer,maxrows As Integer
	Dim ViewString As String, Scope As String, GetField As Variant
	Dim C As NotesViewColumn, FieldName As String, K As Integer,N As Integer
	Dim xlApp As Variant, xlsheet As Variant, rows As Integer, cols As Integer
	Dim nitem As NotesItem , entry As NotesViewEntry, vwNav As NotesViewNavigator
	Dim ShowView()  As Variant, i As Integer, VList As Variant, ColVals As Variant
	Dim fso As Variant

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
    maxrows=dataview.RowLines
	'Kill("d:\Book1.xlsx")
	Dim File_Name As String 
	'ตั้งชื่อ file ที่ต้องการ
	File_Name = "d:\123.csv"
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

    Set fso = CreateObject("Scripting.FileSystemObject")
	Dim oFile As Variant
	Set oFile = FSO.CreateTextFile(File_Name)

	rows=2  'column headings starts in row 2
	For K=1 To maxcols
		Set c=dataview.columns(K-1)
            if k=maxcols Then
                oFile.Write c.title
                oFile.WriteLine
            else
                oFile.Write c.title +","
            end if
		cols = cols + 1
	Next K

	Set entry=vwnav.GetFirstDocument
	rows=3   'data starts in third row
	Do While Not (entry Is Nothing)
		For cols=1 To maxcols 
			colvals=entry.ColumnValues(cols-1) 'subscript =0
                if cols = maxcols Then
                    scope=Typename(colvals)
                    Select Case scope
                    Case "STRING"
                        oFile.Write colvals
                    Case Else 
                        oFile.Write colvals
                    End Select 
                else
                    scope=Typename(colvals)
                    Select Case scope
                    Case "STRING"
                        oFile.Write colvals+","
                    Case Else 
                        oFile.Write colvals+","
                    End Select 
                end If
		Next cols  
		rows=rows+1
		Set entry = vwnav.getnextdocument(entry)  
        oFile.WriteLine
	Loop
    oFile.Close
	Set fso = Nothing
	Set oFile = Nothing    
    

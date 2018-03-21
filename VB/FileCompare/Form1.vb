Imports System.IO
' File create by David Banville march 19th 2018
' Based on Dynamic DataGridView by John Simons Pentair (https://code.msdn.microsoft.com/windowsdesktop/Create-a-Dynamic-f779794b#content)
Public Class Form1
    'Create a new datagrid
    Dim WithEvents DataGrid1 As New DataGridView()
    Dim WithEvents DataGrid2 As New DataGridView()

    Private FILE_NAME As String
    Private FILE_NAME_REF As String
    Private HEADER_LINE As String

    Sub SaveDataGrid2File(dvg As Object, file As String)
        'Here we save the modified file
        Dim fileToCreate As System.IO.FileInfo = New System.IO.FileInfo(file)
        Dim objWriter As New System.IO.StreamWriter(file)
        Dim value As String = ""
        If HEADER_LINE IsNot Nothing Then
            objWriter.WriteLine(HEADER_LINE)
        End If
        For row As Integer = 0 To dvg.RowCount - 1
            For col As Integer = 0 To dvg.ColumnCount - 1
                If col <> dvg.ColumnCount - 1 Then
                    If dvg.Rows(row).Cells(col).Value Is Nothing Then
                        value = value & txtColumnSeperator.Text
                    Else
                        value = value & dvg.Rows(row).Cells(col).Value.ToString & txtColumnSeperator.Text
                    End If
                Else
                    If dvg.Rows(row).Cells(col).Value Is Nothing Then
                        value = value
                    Else
                        value = value & dvg.Rows(row).Cells(col).Value.ToString
                    End If
                End If
            Next
            objWriter.WriteLine(value)
            value = ""
        Next
        objWriter.Close()
        Application.DoEvents()
    End Sub

    Sub PopulateDataGridView(DataGrid As Object, file As String)
        Try
            'Clear rows and columns (if you click the button twice they will be cleared first).
            DataGrid.Rows.Clear()
            DataGrid.Columns.Clear()
            If System.IO.File.Exists(file) = False Then
                'If you do not have sample data yet, we just create one for the test of this form
                'CreateSampleFile(file)
            End If
            'Opening the text file
            Dim objReader As New System.IO.StreamReader(file)
            Dim HeaderLine As String = ""
            Dim ColHeaders As Array
            Dim NrOfCols As Integer = 0
            Dim TextLine As String = ""
            Dim Items As Array
            'I know, we just created it, but we need to check this if saving failed for any reason 
            If System.IO.File.Exists(file) = True Then
                If CbxLoadHeaders.Checked = True Then
                    'If the user clicked the first columns is headers then we do so
                    HeaderLine = objReader.ReadLine()
                    HEADER_LINE = HeaderLine
                    ColHeaders = Split(HeaderLine, txtColumnSeperator.Text)
                    NrOfCols = UBound(ColHeaders)
                    For Each value In ColHeaders
                        Dim col As New DataGridViewTextBoxColumn

                        col.DataPropertyName = value
                        col.HeaderText = value
                        col.Name = value
                        DataGrid.Columns.Add(col)
                    Next
                Else
                    'First row is not the column headers so we have to create some
                    'Lets look at the number of columns first
                    'We use a new reader to not disturb the first row 
                    Dim ColReader As New System.IO.StreamReader(file)
                    Dim DColumns As String = ColReader.ReadLine()
                    Dim ColumnSplit = Split(DColumns, txtColumnSeperator.Text)
                    NrOfCols = UBound(ColumnSplit)
                    ColReader.Dispose()
                    ColReader.Close()
                    'Here we just create some headers
                    For x = 0 To NrOfCols
                        Dim col As New DataGridViewTextBoxColumn
                        col.DataPropertyName = "dgvColumn_" & Trim(x.ToString)
                        col.HeaderText = "Column " & Trim(x.ToString)
                        col.Name = "dgvColumn_" & Trim(x.ToString)
                        DataGrid.Columns.Add(col)
                    Next
                End If
                'reading the (rest of the) file.
                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine()
                    'Lets just skip empty lines
                    If Trim(TextLine) <> "" Then
                        'splitting the textlines
                        Items = Split(TextLine, txtColumnSeperator.Text)
                        Dim n As Integer = DataGrid.Rows.Add()
                        'If the nr of columns is less than the columncount we just leave it blank, so we only use the UBound(items)
                        'If it contains more columns it skips them anyway
                        Dim UsedColumns As Integer = 0
                        If DataGrid.Columns.Count > UBound(Items) + 1 Then
                            UsedColumns = UBound(Items)
                        Else
                            UsedColumns = DataGrid.Columns.Count - 1
                        End If
                        For x = 0 To UsedColumns
                            'put each item in a cell
                            DataGrid.Rows.Item(n).Cells(x).Value = Items(x)
                            Try
                                If DataGrid2.Rows.Item(n).Cells(x).Value.ToString <> DataGrid1.Rows.Item(n).Cells(x).Value.ToString Then
                                    DataGrid1.Rows.Item(n).Cells(x).Style.BackColor = Color.Yellow
                                    DataGrid2.Rows.Item(n).Cells(x).Style.BackColor = Color.Yellow
                                Else
                                    DataGrid1.Rows.Item(n).Cells(x).Style.BackColor = Color.White
                                    DataGrid2.Rows.Item(n).Cells(x).Style.BackColor = Color.White
                                End If
                            Catch
                            End Try
                        Next x
                    End If
                Loop
            End If
            objReader.Close()
            objReader.Dispose()
        Catch ex As Exception
            'If an error occures show this on the error label and clear the view to make shure data is not misinterpreted
            Debug.Print(ex.ToString)
            DataGrid.Rows.Clear()
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub BtnLoadRef_Click(sender As Object, e As EventArgs) Handles BtnLoadRef.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\Users\david\Documents\Visual Studio 2017\Code Snippets\Visual Basic\DynamicDataGridView\VB\CSV Read to GridView sample\bin\Debug"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            FILE_NAME_REF = fd.FileName
            TextBoxRef.Text = FILE_NAME_REF
        End If

        'add the datagrid to the form
        Me.Controls.Add(DataGrid1)

        'Set the position and size of the first datagrid
        DataGrid1.Left = 50
        DataGrid1.Top = 100
        DataGrid1.Width = Me.Width / 2 - 100
        DataGrid1.Height = Me.Height - 200

        lblError.Top = Me.Height - 150
        lblError.Left = 50

        'Creating dynamic columns
        Application.DoEvents()
        PopulateDataGridView(DataGrid1, FILE_NAME_REF)
    End Sub

    Private Sub TextBoxRef_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRef.TextChanged
        FILE_NAME_REF = TextBoxRef.Text
    End Sub

    Private Sub DataGrid2_CellValueChanged(sender As Object, e As EventArgs) Handles DataGrid2.CellValueChanged
        Dim CurrentValue As String = DataGrid2.CurrentCell.Value.ToString
        Dim CurrentRowIndex As Integer = DataGrid2.CurrentCell.RowIndex
        Dim CurrentColIndex As Integer = DataGrid2.CurrentCell.ColumnIndex
        Try
            If DataGrid1.Rows(CurrentRowIndex).Cells(CurrentColIndex).Value.ToString <> CurrentValue Then
                DataGrid2.CurrentCell.Style.BackColor = Color.Yellow
                DataGrid1.CurrentCell.Style.BackColor = Color.Yellow
            Else
                DataGrid2.CurrentCell.Style.BackColor = Color.White
                DataGrid1.CurrentCell.Style.BackColor = Color.White
            End If
        Catch
        End Try
    End Sub

    Private Sub TextBoxFile_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFile.TextChanged
        FILE_NAME = TextBoxFile.Text
    End Sub

    Private Sub BtnLoadFile_Click(sender As Object, e As EventArgs) Handles BtnLoadFile.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\Users\david\Documents\Visual Studio 2017\Code Snippets\Visual Basic\DynamicDataGridView\VB\CSV Read to GridView sample\bin\Debug"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            FILE_NAME = fd.FileName
            TextBoxFile.Text = FILE_NAME
        End If
        Me.Controls.Add(DataGrid2)

        'Set the position and size of the second datagrid
        DataGrid2.Top = 100
        DataGrid2.Width = Me.Width / 2 - 100
        DataGrid2.Left = Me.Width - DataGrid2.Width - 50
        DataGrid2.Height = Me.Height - 200
        lblError.Top = Me.Height - 150
        lblError.Left = 50

        PopulateDataGridView(DataGrid2, FILE_NAME)
    End Sub

    Private Sub BtnSaveAs_Click(sender As Object, e As EventArgs) Handles BtnSaveAs.Click
        Dim fd As SaveFileDialog = New SaveFileDialog()
        fd.FileName = FILE_NAME & ".txt"
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\Users\david\Documents\Visual Studio 2017\Code Snippets\Visual Basic\DynamicDataGridView\VB\CSV Read to GridView sample\bin\Debug"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        If fd.ShowDialog() = DialogResult.OK Then
            SaveDataGrid2File(DataGrid2, fd.FileName)
        End If

    End Sub
End Class
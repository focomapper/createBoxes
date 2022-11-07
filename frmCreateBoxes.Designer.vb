<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateBoxes
  Inherits System.Windows.Forms.UserControl

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Me.lblRows = New System.Windows.Forms.Label()
        Me.lblColumns = New System.Windows.Forms.Label()
        Me.tbColumns = New System.Windows.Forms.TextBox()
        Me.tbRows = New System.Windows.Forms.TextBox()
        Me.bExecute = New System.Windows.Forms.Button()
        Me.bClearAll = New System.Windows.Forms.Button()
        Me.chkDisplayGfx = New System.Windows.Forms.CheckBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btnColorPkr = New System.Windows.Forms.Button()
        Me.txtColorSwatch = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblRows
        '
        Me.lblRows.AutoSize = True
        Me.lblRows.Location = New System.Drawing.Point(13, 17)
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(34, 13)
        Me.lblRows.TabIndex = 0
        Me.lblRows.Text = "Rows"
        '
        'lblColumns
        '
        Me.lblColumns.AutoSize = True
        Me.lblColumns.Location = New System.Drawing.Point(153, 17)
        Me.lblColumns.Name = "lblColumns"
        Me.lblColumns.Size = New System.Drawing.Size(47, 13)
        Me.lblColumns.TabIndex = 1
        Me.lblColumns.Text = "Columns"
        '
        'tbColumns
        '
        Me.tbColumns.Location = New System.Drawing.Point(206, 14)
        Me.tbColumns.Name = "tbColumns"
        Me.tbColumns.Size = New System.Drawing.Size(68, 20)
        Me.tbColumns.TabIndex = 2
        '
        'tbRows
        '
        Me.tbRows.Location = New System.Drawing.Point(53, 14)
        Me.tbRows.Name = "tbRows"
        Me.tbRows.Size = New System.Drawing.Size(66, 20)
        Me.tbRows.TabIndex = 3
        '
        'bExecute
        '
        Me.bExecute.Location = New System.Drawing.Point(27, 49)
        Me.bExecute.Name = "bExecute"
        Me.bExecute.Size = New System.Drawing.Size(92, 23)
        Me.bExecute.TabIndex = 4
        Me.bExecute.Text = "Create Boxes!"
        Me.bExecute.UseVisualStyleBackColor = True
        '
        'bClearAll
        '
        Me.bClearAll.Location = New System.Drawing.Point(194, 86)
        Me.bClearAll.Name = "bClearAll"
        Me.bClearAll.Size = New System.Drawing.Size(59, 23)
        Me.bClearAll.TabIndex = 5
        Me.bClearAll.Text = "Clear All"
        Me.bClearAll.UseVisualStyleBackColor = True
        '
        'chkDisplayGfx
        '
        Me.chkDisplayGfx.AutoSize = True
        Me.chkDisplayGfx.Checked = True
        Me.chkDisplayGfx.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDisplayGfx.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDisplayGfx.Location = New System.Drawing.Point(27, 92)
        Me.chkDisplayGfx.Name = "chkDisplayGfx"
        Me.chkDisplayGfx.Size = New System.Drawing.Size(92, 17)
        Me.chkDisplayGfx.TabIndex = 6
        Me.chkDisplayGfx.Text = "Display Boxes"
        Me.chkDisplayGfx.UseVisualStyleBackColor = True
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AllowFullOpen = False
        '
        'btnColorPkr
        '
        Me.btnColorPkr.Location = New System.Drawing.Point(156, 49)
        Me.btnColorPkr.Name = "btnColorPkr"
        Me.btnColorPkr.Size = New System.Drawing.Size(64, 23)
        Me.btnColorPkr.TabIndex = 7
        Me.btnColorPkr.Text = "Pick Color"
        Me.btnColorPkr.UseVisualStyleBackColor = True
        '
        'txtColorSwatch
        '
        Me.txtColorSwatch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtColorSwatch.Location = New System.Drawing.Point(233, 49)
        Me.txtColorSwatch.Multiline = True
        Me.txtColorSwatch.Name = "txtColorSwatch"
        Me.txtColorSwatch.Size = New System.Drawing.Size(41, 23)
        Me.txtColorSwatch.TabIndex = 8
        '
        'frmCreateBoxes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtColorSwatch)
        Me.Controls.Add(Me.btnColorPkr)
        Me.Controls.Add(Me.chkDisplayGfx)
        Me.Controls.Add(Me.bClearAll)
        Me.Controls.Add(Me.bExecute)
        Me.Controls.Add(Me.tbRows)
        Me.Controls.Add(Me.tbColumns)
        Me.Controls.Add(Me.lblColumns)
        Me.Controls.Add(Me.lblRows)
        Me.MaximumSize = New System.Drawing.Size(295, 130)
        Me.MinimumSize = New System.Drawing.Size(295, 130)
        Me.Name = "frmCreateBoxes"
        Me.Size = New System.Drawing.Size(293, 128)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRows As System.Windows.Forms.Label
    Friend WithEvents lblColumns As System.Windows.Forms.Label
    Friend WithEvents tbColumns As System.Windows.Forms.TextBox
    Friend WithEvents tbRows As System.Windows.Forms.TextBox
    Friend WithEvents bExecute As System.Windows.Forms.Button
    Friend WithEvents bClearAll As System.Windows.Forms.Button
    Friend WithEvents chkDisplayGfx As System.Windows.Forms.CheckBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnColorPkr As System.Windows.Forms.Button
    Friend WithEvents txtColorSwatch As System.Windows.Forms.TextBox

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btSend = New System.Windows.Forms.Button()
        Me.txInput = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txData = New System.Windows.Forms.RichTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chTime = New System.Windows.Forms.CheckBox()
        Me.chScroll = New System.Windows.Forms.CheckBox()
        Me.cmbLine = New System.Windows.Forms.ComboBox()
        Me.cmbBaud = New System.Windows.Forms.ComboBox()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btSend)
        Me.Panel1.Controls.Add(Me.txInput)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 32)
        Me.Panel1.TabIndex = 0
        '
        'btSend
        '
        Me.btSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSend.Location = New System.Drawing.Point(807, 5)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(72, 23)
        Me.btSend.TabIndex = 1
        Me.btSend.Text = "Send"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'txInput
        '
        Me.txInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.txInput.Location = New System.Drawing.Point(3, 6)
        Me.txInput.Name = "txInput"
        Me.txInput.Size = New System.Drawing.Size(798, 21)
        Me.txInput.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(882, 384)
        Me.Panel2.TabIndex = 1
        '
        'txData
        '
        Me.txData.BackColor = System.Drawing.Color.White
        Me.txData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.txData.Location = New System.Drawing.Point(0, 0)
        Me.txData.Name = "txData"
        Me.txData.ReadOnly = True
        Me.txData.Size = New System.Drawing.Size(882, 384)
        Me.txData.TabIndex = 0
        Me.txData.Text = ""
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chTime)
        Me.Panel3.Controls.Add(Me.chScroll)
        Me.Panel3.Controls.Add(Me.cmbLine)
        Me.Panel3.Controls.Add(Me.cmbBaud)
        Me.Panel3.Controls.Add(Me.btClear)
        Me.Panel3.Controls.Add(Me.btRefresh)
        Me.Panel3.Controls.Add(Me.cmbPort)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 416)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(882, 33)
        Me.Panel3.TabIndex = 1
        '
        'chTime
        '
        Me.chTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chTime.AutoSize = True
        Me.chTime.Location = New System.Drawing.Point(460, 8)
        Me.chTime.Name = "chTime"
        Me.chTime.Size = New System.Drawing.Size(103, 17)
        Me.chTime.TabIndex = 3
        Me.chTime.Text = "Show timestamp"
        Me.chTime.UseVisualStyleBackColor = True
        '
        'chScroll
        '
        Me.chScroll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chScroll.AutoSize = True
        Me.chScroll.Location = New System.Drawing.Point(379, 8)
        Me.chScroll.Name = "chScroll"
        Me.chScroll.Size = New System.Drawing.Size(72, 17)
        Me.chScroll.TabIndex = 2
        Me.chScroll.Text = "Autoscroll"
        Me.chScroll.UseVisualStyleBackColor = True
        '
        'cmbLine
        '
        Me.cmbLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLine.FormattingEnabled = True
        Me.cmbLine.Items.AddRange(New Object() {"No line ending", "Newline", "Carriage return", "Both NL && CR"})
        Me.cmbLine.Location = New System.Drawing.Point(569, 6)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Size = New System.Drawing.Size(100, 21)
        Me.cmbLine.TabIndex = 1
        '
        'cmbBaud
        '
        Me.cmbBaud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Items.AddRange(New Object() {"300 baud", "1200 baud", "2400 baud", "4800 baud", "9600 baud", "19200 baud", "38400 baud", "57600 baud", "74880 baud", "115200 baud", "230400 baud", "250000 baud", "500000 baud", "1000000 baud", "2000000 baud"})
        Me.cmbBaud.Location = New System.Drawing.Point(675, 6)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(100, 21)
        Me.cmbBaud.TabIndex = 0
        '
        'btClear
        '
        Me.btClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClear.Location = New System.Drawing.Point(781, 5)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(92, 23)
        Me.btClear.TabIndex = 0
        Me.btClear.Text = "Clear Output"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(228, 5)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(72, 23)
        Me.btRefresh.TabIndex = 6
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'cmbPort
        '
        Me.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Items.AddRange(New Object() {"No line ending", "Newline", "Carriage return", "Both NL && CR"})
        Me.cmbPort.Location = New System.Drawing.Point(12, 6)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(210, 21)
        Me.cmbPort.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 449)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Custom Serial Monitor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents cmbLine As System.Windows.Forms.ComboBox
    Friend WithEvents chTime As System.Windows.Forms.CheckBox
    Friend WithEvents chScroll As System.Windows.Forms.CheckBox
    Friend WithEvents txInput As System.Windows.Forms.TextBox
    Friend WithEvents btSend As System.Windows.Forms.Button
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents txData As System.Windows.Forms.RichTextBox

End Class

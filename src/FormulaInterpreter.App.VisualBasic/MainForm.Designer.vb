<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.tbFormula = New System.Windows.Forms.TextBox()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.lblFormula = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.resultText = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbFormula
        '
        Me.tbFormula.Location = New System.Drawing.Point(70, 12)
        Me.tbFormula.Name = "tbFormula"
        Me.tbFormula.Size = New System.Drawing.Size(175, 20)
        Me.tbFormula.TabIndex = 0
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(251, 10)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(75, 23)
        Me.btnCalc.TabIndex = 1
        Me.btnCalc.Text = "Rechne"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'lblFormula
        '
        Me.lblFormula.AutoSize = True
        Me.lblFormula.Location = New System.Drawing.Point(26, 15)
        Me.lblFormula.Name = "lblFormula"
        Me.lblFormula.Size = New System.Drawing.Size(38, 13)
        Me.lblFormula.TabIndex = 2
        Me.lblFormula.Text = "Formel"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(16, 40)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(48, 13)
        Me.lblResult.TabIndex = 3
        Me.lblResult.Text = "Ergebnis"
        '
        'resultText
        '
        Me.resultText.AutoSize = True
        Me.resultText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resultText.Location = New System.Drawing.Point(70, 40)
        Me.resultText.Name = "resultText"
        Me.resultText.Size = New System.Drawing.Size(14, 13)
        Me.resultText.TabIndex = 4
        Me.resultText.Text = "0"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 87)
        Me.Controls.Add(Me.resultText)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lblFormula)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.tbFormula)
        Me.Name = "MainForm"
        Me.Text = "Formel-Interpreter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbFormula As TextBox
    Friend WithEvents btnCalc As Button
    Friend WithEvents lblFormula As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents resultText As Label
End Class

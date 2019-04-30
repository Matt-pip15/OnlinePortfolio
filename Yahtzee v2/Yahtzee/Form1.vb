Public Class Form1

    Dim roll1 As Integer   'Work on lock command using arrays
    Dim roll2 As Integer
    Dim roll3 As Integer
    Dim roll4 As Integer
    Dim roll5 As Integer
    Dim total As Integer = 0
    Dim count As Integer = 0
    Dim upper As Integer = 0
    Dim lower As Integer = 0
    Dim bonusYatzee As Integer = 0
    Dim upperBonus As Integer = 0
    Dim die1L, Die2L, Die3L, Die4L, Die5L As Boolean
    Dim enabled1, enabled2, enabled3, enabled4, enabled5, enabled6 As Boolean
    Dim kind3En, kind4En, FullEn, smlEn, LrgEn, yahtzeeEn, ChanceEn, colorIndicate As Boolean
    Dim rollArray() As Integer = {roll1, roll2, roll3, roll4, roll5}
    Dim str As String = CStr(roll1) & CStr(roll2) & CStr(roll3) & CStr(roll4) & CStr(roll5)
    Dim strTest As String = "32622"
    Dim tempRoll As Integer
    Dim bol As Boolean = True
    Dim lrg As Boolean = False
    Dim tempPoints As Integer
    Dim debug As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        closeButtons()
        enabled1 = True
        enabled2 = True
        enabled3 = True
        enabled4 = True
        enabled5 = True
        enabled6 = True
        kind3En = True
        kind4En = True
        FullEn = True
        smlEn = True
        LrgEn = True
        ChanceEn = True
        yahtzeeEn = True
        colorIndicate = True
        str = CStr(roll1) & CStr(roll2) & CStr(roll3) & CStr(roll4) & CStr(roll5)
        btnChance.BackColor = Color.Green
    End Sub
    Private Sub RollDie1()
        If die1L = False Then
            roll1 = Int(Rnd() * 6) + 1
            Select Case roll1
                Case 1
                    pb1.Image = die1.Image

                Case 2
                    pb1.Image = die2.Image

                Case 3
                    pb1.Image = die3.Image

                Case 4
                    pb1.Image = die4.Image

                Case 5
                    pb1.Image = die5.Image

                Case 6
                    pb1.Image = die6.Image
            End Select
        End If
        Select Case roll1
            Case 1
                pb1.Image = die1.Image

            Case 2
                pb1.Image = die2.Image

            Case 3
                pb1.Image = die3.Image

            Case 4
                pb1.Image = die4.Image

            Case 5
                pb1.Image = die5.Image

            Case 6
                pb1.Image = die6.Image


        End Select
    End Sub
    Private Sub RollDie2()
        If Die2L = False Then
            roll2 = Int(Rnd() * 6) + 1
            Select Case roll2
                Case 1
                    pb2.Image = die1.Image

                Case 2
                    pb2.Image = die2.Image

                Case 3
                    pb2.Image = die3.Image

                Case 4
                    pb2.Image = die4.Image

                Case 5
                    pb2.Image = die5.Image

                Case 6
                    pb2.Image = die6.Image

            End Select
        End If
    End Sub
    Private Sub RollDie3()

        If Die3L = False Then
            roll3 = Int(Rnd() * 6) + 1
            Select Case roll3
                Case 1
                    pb3.Image = die1.Image

                Case 2
                    pb3.Image = die2.Image

                Case 3
                    pb3.Image = die3.Image

                Case 4
                    pb3.Image = die4.Image

                Case 5
                    pb3.Image = die5.Image

                Case 6
                    pb3.Image = die6.Image
            End Select
        End If
    End Sub
    Private Sub RollDie4()
        If Die4L = False Then
            roll4 = Int(Rnd() * 6) + 1
            Select Case roll4
                Case 1
                    pb4.Image = die1.Image

                Case 2
                    pb4.Image = die2.Image

                Case 3
                    pb4.Image = die3.Image

                Case 4
                    pb4.Image = die4.Image

                Case 5
                    pb4.Image = die5.Image

                Case 6
                    pb4.Image = die6.Image
            End Select
        End If
    End Sub
    Private Sub RollDie5()
        'If Die5L = False Then
        If Die5L = False Then
            roll5 = Int(Rnd() * 6) + 1
            Select Case roll5
                Case 1
                    pb5.Image = die1.Image

                Case 2
                    pb5.Image = die2.Image

                Case 3
                    pb5.Image = die3.Image

                Case 4
                    pb5.Image = die4.Image

                Case 5
                    pb5.Image = die5.Image

                Case 6
                    pb5.Image = die6.Image
            End Select
        End If
    End Sub

    Private Sub btnRoll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll.Click
        Timer1.Enabled = True
        If (count = 1) Then
            btnRoll.BackColor = Color.Yellow
        ElseIf (count = 2) Then
            btnRoll.BackColor = Color.Red
        End If

        count += 1
        If count = 3 Then
            btnRoll.Enabled = False
        End If
    End Sub
    Private Function RollOver() As Boolean
        If tempRoll > 5 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RollDie1()
        RollDie2()
        RollDie3()
        RollDie4()
        RollDie5()
        tempRoll += 1
        If RollOver() Then
            str = CStr(roll1) & CStr(roll2) & CStr(roll3) & CStr(roll4) & CStr(roll5)
            tempRoll = 0
            Timer1.Enabled = False
            If colorIndicate = True Then
                check1()
                check2()
                check3()
                check4()
                check5()
                check6()
                check3kind()
                check4kind()
                checkFull()
                checkSml()
                checkLrg()
                checkYahtzee()
            End If
            openButtons()
        End If
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("1") Then
                points += 1
            End If
            letter += 1
        End While
        If points = 5 And btnYAHTZEE.Enabled = False And lblYAHTZEE.Text = "50" Then
            bonusYatzee += 50
        End If
        lbl1.Text = CStr(points)
        btnRoll.Enabled = True
        btn1.Enabled = False
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        upper += points
        total += points
        If upper >= 63 And bol = True Then
            upperBonus += 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblUpper.Text = CStr(upper)
        lblYahtzeebonus.Text = CStr(bonusYatzee)
        lblTotal.Text = CStr(total)
        count = 0
        enabled1 = False
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("2") Then
                points += 2
            End If
            letter += 1
        End While
        If points = 5 And btnYAHTZEE.Enabled = False And lblYAHTZEE.Text = "50" Then
            bonusYatzee += 50
        End If
        lbl2.Text = CStr(points)
        btnRoll.Enabled = True
        btn2.Enabled = False
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        upper += points
        total += points
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblUpper.Text = CStr(upper)
        lblYahtzeebonus.Text = CStr(bonusYatzee)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        count = 0
        enabled2 = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("3") Then
                points += 3
            End If
            letter += 1
        End While
        If points = 5 And btnYAHTZEE.Enabled = False And lblYAHTZEE.Text = "50" Then
            bonusYatzee += 50
        End If
        lbl3.Text = CStr(points)
        btnRoll.Enabled = True
        btn3.Enabled = False
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        upper += points
        total += points
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblUpper.Text = CStr(upper)
        lblYahtzeebonus.Text = CStr(bonusYatzee)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        count = 0
        enabled3 = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("4") Then
                points += 4
            End If
            letter += 1
        End While
        If points = 5 And btnYAHTZEE.Enabled = False And lblYAHTZEE.Text = "50" Then
            bonusYatzee += 50
        End If
        lbl4.Text = CStr(points)
        btnRoll.Enabled = True
        btn4.Enabled = False
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        upper += points
        total += points
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblUpper.Text = CStr(upper)
        lblYahtzeebonus.Text = CStr(bonusYatzee)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        count = 0
        enabled4 = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("5") Then
                points += 5
            End If
            letter += 1
        End While
        If points = 5 And btnYAHTZEE.Enabled = False And lblYAHTZEE.Text = "50" Then
            bonusYatzee += 50
        End If
        lbl5.Text = CStr(points)
        btnRoll.Enabled = True
        btn5.Enabled = False
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        upper += points
        total += points
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblUpper.Text = CStr(upper)
        lblYahtzeebonus.Text = CStr(bonusYatzee)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        count = 0
        enabled5 = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("6") Then
                points += 6
            End If
            letter += 1
        End While
        If points = 5 And btnYAHTZEE.Enabled = False And lblYAHTZEE.Text = "50" Then
            bonusYatzee += 50
        End If
        lbl6.Text = CStr(points)
        btnRoll.Enabled = True
        btn6.Enabled = False
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        upper += points
        total += points
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        lblUpperBonus.Text = CStr(upperBonus)
        lblUpper.Text = CStr(upper)
        lblYahtzeebonus.Text = CStr(bonusYatzee)
        lblTotal.Text = CStr(total)
        count = 0
        enabled6 = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btn3kind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3kind.Click
        Dim chr As Integer = 0
        Dim points As Integer = 0
        Dim temp As String
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        For chr = 0 To 4
            temp = str.Chars(chr)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 >= 3 Or num2 >= 3 Or num3 >= 3 Or num4 >= 3 Or num5 >= 3 Or num6 >= 3 Then
            points += roll1 + roll2 + roll3 + roll4 + roll5
        End If
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lbl3kind.Text = CStr(points)
        lower += points
        total += points
        lblLower.Text = CStr(lower)
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        btnRoll.Enabled = True
        btn3kind.Enabled = False
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        count = 0
        lblTotal.Text = CStr(total)
        kind3En = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btn4kind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4kind.Click
        Dim chr As Integer = 0
        Dim points As Integer = 0
        Dim temp As String
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        For chr = 0 To 4
            temp = str.Chars(chr)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 >= 4 Or num2 >= 4 Or num3 >= 4 Or num4 >= 4 Or num5 >= 4 Or num6 >= 4 Then
            points += roll1 + roll2 + roll3 + roll4 + roll5
        End If
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        btn4kind.Enabled = False
        lbl4kind.Text = CStr(points)
        lower += points
        total += points
        lblLower.Text = CStr(lower)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        btnRoll.Enabled = True
        btn4kind.Enabled = False
        lblTotal.Text = CStr(total)
        count = 0
        kind4En = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btnFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFull.Click
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim temp As String
        Dim tempNum1 As String = ""
        Dim tempNum2 As String = ""
        Dim tempBol As Boolean = True
        Dim tempbol2 As Boolean = True
        Dim pause As Boolean = False
        Dim arraylist As New ArrayList
        Dim stir As String = ""

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()

        For i = 0 To 4
            temp = arraylist(i)
            If i = 0 Then
                tempNum1 = temp
                num1 += 1
                tempbol2 = False
            End If
            If tempbol2 = False Then
                If temp <> tempNum1 And tempBol = True Then
                    tempNum2 = temp
                    num2 += 1
                    tempBol = False
                    pause = True
                End If
            End If
            If temp = tempNum1 And tempbol2 = False And i <> 0 Then
                num1 += 1
            ElseIf temp = tempNum2 And tempBol = False And tempbol2 = False And pause = False Then
                num2 += 1
            End If
            If pause = True Then
                pause = False
            End If
        Next
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If

        If num1 = 2 And num2 = 3 Or num1 = 3 And num2 = 2 Then
            points = 25
        Else
            points = 0
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblFull.Text = CStr(points)
        lower += points
        total += points
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        count = 0
        btnRoll.Enabled = True
        btnFull.Enabled = False
        lblLower.Text = CStr(lower)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        FullEn = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btnChance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChance.Click
        Dim points As Integer = 0
        points = roll1 + roll2 + roll3 + roll4 + roll5
        lblChance.Text = CStr(points)
        lower += points
        total += points
        lblTotal.Text = CStr(total)
        lblLower.Text = CStr(lower)
        btnChance.Enabled = False
        btnRoll.Enabled = True
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        count = 3

        If debug = True Then
            str = txtStr.Text
        End If

        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btnSml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSml.Click
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim temp As String
        Dim tempbol As Boolean = False
        Dim tempStr As String = ""
        Dim arraylist As New ArrayList
        Dim repeat As New ArrayList
        smlLrg()

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()

        For i = 0 To 4
            temp = arraylist(i)
            If i = 4 Then
                If temp = arraylist(i - 1) Then
                    repeat.Add(temp)
                End If
            Else
                If temp = arraylist(i + 1) Then
                    repeat.Add(temp)
                End If
            End If

            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 <= 2 And num1 > 0 And num2 <= 2 And num2 > 0 And num3 <= 2 And num3 > 0 And num4 <= 2 And num4 > 0 Or num2 <= 2 And num2 > 0 _
            And num2 <= 2 And num2 > 0 And num3 = 1 And num3 = 1 And num4 <= 2 And num4 > 0 And num5 = 1 And num5 = 1 Or num3 <= 2 And num3 > 0 _
            And num4 <= 2 And num4 > 0 And num5 <= 2 And num5 > 0 And num6 <= 2 And num6 > 0 Or lrg = True Then
            points = 30
            tempbol = True
        End If


        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblSml.Text = CStr(points)
        lower += points
        total += points
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        count = 0
        btnSml.Enabled = False
        btnRoll.Enabled = True
        lblLower.Text = CStr(lower)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        smlEn = False
        lrg = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btnLrg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLrg.Click
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim tempStr As String = ""

        If debug = True Then
            str = txtStr.Text
        End If

        Dim arraylist As New ArrayList
        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()
        tempStr = arraylist.ToString()
        Dim temp As String
        For i = 0 To 4
            temp = arraylist(i)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
            If num1 = 1 And num2 = 1 And num3 = 1 And num4 = 1 And num5 = 1 Or num2 = 1 And num3 = 1 And num4 = 1 And num5 = 1 And num6 = 1 Then
                points = 40
            End If
        Next
        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblLrg.Text = CStr(points)
        lower += points
        total += points
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        count = 0
        btnLrg.Enabled = False
        lblTotal.Text = CStr(total)
        lblLower.Text = CStr(lower)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        btnRoll.Enabled = True
        LrgEn = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub btnYAHTZEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYAHTZEE.Click
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim temp As String
        Dim arraylist As New ArrayList

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        For i = 0 To 4
            temp = arraylist(i)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
            If num1 = 5 Or num2 = 5 Or num3 = 5 Or num4 = 5 Or num5 = 5 Or num6 = 5 Then
                points = 50
            Else
                points = 0
            End If
        Next

        If upper >= 63 And bol = True Then
            upperBonus = 63
            total += upperBonus
            bol = False
        End If
        lblUpperBonus.Text = CStr(upperBonus)
        lblYAHTZEE.Text = CStr(points)
        lower += points
        total += points
        die1L = False
        Die2L = False
        Die3L = False
        Die4L = False
        Die5L = False
        count = 0
        btnYAHTZEE.Enabled = False
        btnRoll.Enabled = True
        lblLower.Text = CStr(lower)
        lblTotal.Text = CStr(total)
        lblLowertotal.Text = CStr(lower + bonusYatzee)
        lblUpperTotal.Text = CStr(upper + upperBonus)
        yahtzeeEn = False
        closeButtons()
        btnRoll.BackColor = Drawing.Color.Green
    End Sub

    Private Sub LockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem1.Click
        die1L = True
    End Sub

    Private Sub UnlockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockToolStripMenuItem.Click
        die1L = False
    End Sub

    Private Sub LockToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem2.Click
        Die2L = True
    End Sub

    Private Sub UnlockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockToolStripMenuItem1.Click
        Die2L = False
    End Sub

    Private Sub LockToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem3.Click
        Die3L = True
    End Sub

    Private Sub UnlockToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockToolStripMenuItem2.Click
        Die3L = False
    End Sub

    Private Sub LockToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem4.Click
        Die4L = True
    End Sub

    Private Sub UnlockToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockToolStripMenuItem3.Click
        Die4L = False
    End Sub

    Private Sub LockToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem5.Click
        Die5L = True
    End Sub

    Private Sub UnlockToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnlockToolStripMenuItem4.Click
        Die5L = False
    End Sub
    Public Sub check1()
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0
        While letter < 5
            tempString = str(letter)
            If tempString.Contains("1") Then
                points += 1
            End If
            letter += 1
        End While
        If points >= 1 Then
            btn1.BackColor = Color.Green
        ElseIf points < 1 Then
            btn1.BackColor = Color.Yellow
        ElseIf enabled1 = False Then
            btn1.BackColor = Color.Red
        End If
    End Sub
    Public Sub check2()
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("2") Then
                points += 2
            End If
            letter += 1
        End While
        If points >= 2 Then
            btn2.BackColor = Color.Green
        ElseIf points < 2 Then
            btn2.BackColor = Color.Yellow
        ElseIf enabled2 = False Then
            btn2.BackColor = Color.Red
        End If
    End Sub
    Public Sub check3()
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("3") Then
                points += 3
            End If
            letter += 1
        End While
        If points >= 3 Then
            btn3.BackColor = Color.Green
        ElseIf points < 3 Then
            btn3.BackColor = Color.Yellow
        ElseIf enabled3 = False Then
            btn3.BackColor = Color.Red
        End If
    End Sub
    Public Sub check4()
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("4") Then
                points += 4
            End If
            letter += 1
        End While
        If points >= 4 Then
            btn4.BackColor = Color.Green
        ElseIf points < 4 Then
            btn4.BackColor = Color.Yellow
        ElseIf enabled4 = False Then
            btn4.BackColor = Color.Red
        End If
    End Sub
    Public Sub check5()
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0
        If debug = True Then
            str = txtStr.Text
        End If
        While letter < 5
            tempString = str(letter)
            If tempString.Contains("5") Then
                points += 5
            End If
            letter += 1
        End While
        If points >= 5 Then
            btn5.BackColor = Color.Green
        ElseIf points < 5 Then
            btn5.BackColor = Color.Yellow
        ElseIf enabled5 = False Then
            btn5.BackColor = Color.Red
        End If
    End Sub
    Public Sub check6()
        Dim letter As Integer = 0
        Dim tempString As String
        Dim points As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        While letter < 5
            tempString = str(letter)
            If tempString.Contains("6") Then
                points += 6
            End If
            letter += 1
        End While
        If points >= 6 Then
            btn6.BackColor = Color.Green
        ElseIf points < 6 Then
            btn6.BackColor = Color.Yellow
        ElseIf enabled6 = False Then
            btn6.BackColor = Color.Red
        End If
    End Sub
    Public Sub check3kind()
        Dim chr As Integer = 0
        Dim points As Integer = 0
        Dim temp As String
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        For chr = 0 To 4
            temp = str.Chars(chr)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 >= 3 Or num2 >= 3 Or num3 >= 3 Or num4 >= 3 Or num5 >= 3 Or num6 >= 3 Then
            btn3kind.BackColor = Color.Green
        Else
            btn3kind.BackColor = Color.Yellow
        End If
    End Sub
    Public Sub check4kind()
        Dim chr As Integer = 0
        Dim points As Integer = 0
        Dim temp As String
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0

        If debug = True Then
            str = txtStr.Text
        End If

        For chr = 0 To 4
            temp = str.Chars(chr)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 >= 4 Or num2 >= 4 Or num3 >= 4 Or num4 >= 4 Or num5 >= 4 Or num6 >= 4 Then
            btn4kind.BackColor = Color.Green
        Else
            btn4kind.BackColor = Color.Yellow
        End If
    End Sub
    Public Sub checkFull()
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim temp As String
        Dim tempNum1 As String = ""
        Dim tempNum2 As String = ""
        Dim tempBol As Boolean = True
        Dim tempbol2 As Boolean = True
        Dim pause As Boolean = False
        Dim arraylist As New ArrayList
        Dim stir As String = ""

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()

        For i = 0 To 4
            temp = arraylist(i)
            If i = 0 Then
                tempNum1 = temp
                num1 += 1
                tempbol2 = False
            End If
            If tempbol2 = False Then
                If temp <> tempNum1 And tempBol = True Then
                    tempNum2 = temp
                    num2 += 1
                    tempBol = False
                    pause = True
                End If
            End If
            If temp = tempNum1 And tempbol2 = False And i <> 0 Then
                num1 += 1
            ElseIf temp = tempNum2 And tempBol = False And tempbol2 = False And pause = False Then
                num2 += 1
            End If
            If pause = True Then
                pause = False
            End If
        Next
        If num1 = 2 And num2 = 3 Or num1 = 3 And num2 = 2 Then
            btnFull.BackColor = Color.Green
        Else
            btnFull.BackColor = Color.Yellow
        End If
    End Sub
    Public Sub checkSml()
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim temp As String
        Dim tempbol As Boolean = False
        Dim tempStr As String = ""
        Dim arraylist As New ArrayList
        Dim repeat As New ArrayList
        smlLrg()

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()
        temp = arraylist.ToString()
        For i = 0 To 4

            temp = arraylist(i)
            If i = 4 Then
                If temp = arraylist(i - 1) Then
                    repeat.Add(temp)
                End If
            Else
                If temp = arraylist(i + 1) Then
                    repeat.Add(temp)
                End If
            End If

            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 <= 2 And num1 > 0 And num2 <= 2 And num2 > 0 And num3 <= 2 And num3 > 0 And num4 <= 2 And num4 > 0 Or num2 <= 2 And num2 > 0 _
             And num2 <= 2 And num2 > 0 And num3 = 1 And num3 = 1 And num4 <= 2 And num4 > 0 And num5 = 1 And num5 = 1 Or num3 <= 2 And num3 > 0 _
             And num4 <= 2 And num4 > 0 And num5 <= 2 And num5 > 0 And num6 <= 2 And num6 > 0 Or lrg = True Then
            btnSml.BackColor = Color.Green
        Else
            btnSml.BackColor = Color.Yellow
        End If
        

    End Sub
    Public Sub checkLrg()
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim tempStr As String = ""
        Dim arraylist As New ArrayList

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()
        tempStr = arraylist.ToString()
        Dim temp As String
        For i = 0 To 4
            temp = str.Chars(i)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
            If num1 = 1 And num2 = 1 And num3 = 1 And num4 = 1 And num5 = 1 Or num2 = 1 And num3 = 1 And num4 = 1 And num5 = 1 And num6 = 1 Then
                btnLrg.BackColor = Color.Green
                lrg = True
            Else
                btnLrg.BackColor = Color.Yellow
            End If
        Next
    End Sub
    Public Sub checkYahtzee()
        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim temp As String

        If debug = True Then
            str = txtStr.Text
        End If

        For i = 0 To 4
            temp = str.Chars(i)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 = 5 Or num2 = 5 Or num3 = 5 Or num4 = 5 Or num5 = 5 Or num6 = 5 Then
            btnYAHTZEE.BackColor = Color.Green
        Else
            btnYAHTZEE.BackColor = Color.Yellow
        End If
    End Sub
    Public Sub closeButtons()
        btn1.Enabled = False
        btn2.Enabled = False
        btn3.Enabled = False
        btn4.Enabled = False
        btn5.Enabled = False
        btn6.Enabled = False
        btn3kind.Enabled = False
        btn4kind.Enabled = False
        btnFull.Enabled = False
        btnSml.Enabled = False
        btnLrg.Enabled = False
        btnChance.Enabled = False
        btnYAHTZEE.Enabled = False
    End Sub
    Public Sub openButtons()
        If enabled1 = True Then
            btn1.Enabled = True
        End If
        If enabled2 = True Then
            btn2.Enabled = True
        End If
        If enabled3 = True Then
            btn3.Enabled = True
        End If
        If enabled4 = True Then
            btn4.Enabled = True
        End If
        If enabled5 = True Then
            btn5.Enabled = True
        End If
        If enabled6 = True Then
            btn6.Enabled = True
        End If
        If kind3En = True Then
            btn3kind.Enabled = True
        End If
        If kind4En = True Then
            btn4kind.Enabled = True
        End If
        If FullEn = True Then
            btnFull.Enabled = True
        End If
        If smlEn = True Then
            btnSml.Enabled = True
        End If
        If LrgEn = True Then
            btnLrg.Enabled = True
        End If
        If ChanceEn = True Then
            btnChance.Enabled = True
        End If
        If yahtzeeEn = True Then
            btnYAHTZEE.Enabled = True
        End If
    End Sub
    Private Sub MakeCorrectsmlStrtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If btnSml.Enabled = False Then
            tempPoints = total
            lblSml.Text = 30
            lower += 30
            total += 30
            lblTotal.Text = CStr(total)
            lblLower.Text = CStr(lower)
        End If
    End Sub

    Private Sub RevertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblSml.Text = "0"
        total = tempPoints
        lblTotal.Text = CStr(total)
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        lbl1.Text = Nothing
        lbl2.Text = Nothing
        lbl3.Text = Nothing
        lbl4.Text = Nothing
        lbl5.Text = Nothing
        lbl6.Text = Nothing
        lbl3kind.Text = Nothing
        lbl4kind.Text = Nothing
        lblFull.Text = Nothing
        lblSml.Text = Nothing
        lblLrg.Text = Nothing
        lblChance.Text = Nothing
        lblYAHTZEE.Text = Nothing
        lblUpperTotal.Text = Nothing
        lblLowertotal.Text = Nothing
        lblTotal.Text = Nothing
        lblUpper.Text = Nothing
        lblLower.Text = Nothing
        lblUpperBonus.Text = Nothing
        lblYahtzeebonus.Text = Nothing
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
        btn3kind.Enabled = True
        btn4kind.Enabled = True
        btnFull.Enabled = True
        btnSml.Enabled = True
        btnLrg.Enabled = True
        btnChance.Enabled = True
        btnYAHTZEE.Enabled = True
        btnRoll.Enabled = True
        enabled1 = True
        enabled2 = True
        enabled3 = True
        enabled4 = True
        enabled5 = True
        enabled6 = True
        kind3En = True
        kind4En = True
        FullEn = True
        smlEn = True
        LrgEn = True
        ChanceEn = True
        yahtzeeEn = True
        total = 0
        upper = 0
        lower = 0
        count = 0
        closeButtons()
        pb1.Image = Nothing
        pb2.Image = Nothing
        pb3.Image = Nothing
        pb4.Image = Nothing
        pb5.Image = Nothing
        str = Nothing
        btnRoll.BackColor = Color.Green
        btn1.BackColor = Color.White
        btn2.BackColor = Color.White
        btn3.BackColor = Color.White
        btn4.BackColor = Color.White
        btn5.BackColor = Color.White
        btn6.BackColor = Color.White
        btn3kind.BackColor = Color.White
        btn4kind.BackColor = Color.White
        btnFull.BackColor = Color.White
        btnSml.BackColor = Color.White
        btnLrg.BackColor = Color.White
        btnYAHTZEE.BackColor = Color.White
    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnToolStripMenuItem.Click
        colorIndicate = True
    End Sub

    Private Sub OffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffToolStripMenuItem.Click
        colorIndicate = False
    End Sub
    Public Sub smlLrg()

        Dim points As Integer = 0
        Dim num1 As Integer = 0
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim num4 As Integer = 0
        Dim num5 As Integer = 0
        Dim num6 As Integer = 0
        Dim tempStr As String = ""

        If debug = True Then
            str = txtStr.Text
        End If

        Dim arraylist As New ArrayList
        For i = 0 To 4
            arraylist.Add(str.Chars(i))
        Next
        arraylist.Sort()
        tempStr = arraylist.ToString()
        Dim temp As String
        For i = 0 To 4
            temp = arraylist(i)
            If temp.Contains("1") Then
                num1 += 1
            ElseIf temp.Contains("2") Then
                num2 += 1
            ElseIf temp.Contains("3") Then
                num3 += 1
            ElseIf temp.Contains("4") Then
                num4 += 1
            ElseIf temp.Contains("5") Then
                num5 += 1
            ElseIf temp.Contains("6") Then
                num6 += 1
            End If
        Next
        If num1 = 1 And num2 = 1 And num3 = 1 And num4 = 1 And num5 = 1 Or num2 = 1 And num3 = 1 And num4 = 1 And num5 = 1 And num6 = 1 Then
            lrg = True
        End If
    End Sub

    Private Sub ShowStringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnToolStripMenuItem1.Click
        debug = True
        txtStr.Visible = True
        txtStr.Enabled = True
    End Sub

    Private Sub OffToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffToolStripMenuItem1.Click
        debug = False
        txtStr.Visible = False
        txtStr.Enabled = False
    End Sub
End Class

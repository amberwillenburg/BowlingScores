Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private total1 As Integer
    Private total2 As Integer
    Private total3 As Integer
    Private total4 As Integer

    Dim framevalues1(10) As Integer
    Dim framevalues2(10) As Integer
    Dim framevalues3(10) As Integer
    Dim framevalues4(10) As Integer

    Dim spares1 As New List(Of Integer)()
    Dim strikes1 As New List(Of Integer)()
    Dim spares2 As New List(Of Integer)()
    Dim strikes2 As New List(Of Integer)()
    Dim spares3 As New List(Of Integer)()
    Dim strikes3 As New List(Of Integer)()
    Dim spares4 As New List(Of Integer)()
    Dim strikes4 As New List(Of Integer)()

    Private Sub Strike(frame As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        If n = 1 Then
            total1 -= framevalues1(frame - 1)
            If spares1.Contains(frame - 1) Then
                total1 -= framevalues1(frame - 2)
                total1 += 20
                framevalues1(frame - 2) = 20
                prevbox.Text = total1
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    total1 -= framevalues1(frame - 3)
                    total1 += 30
                    framevalues1(frame - 3) = 30
                    XXbox.Text = total1
                End If
            End If
            strikes1.Add(frame)
        ElseIf n = 2 Then
            total2 -= framevalues2(frame - 1)
            If spares2.Contains(frame - 1) Then
                total2 -= framevalues2(frame - 2)
                total2 += 20
                framevalues2(frame - 2) = 20
                prevbox.Text = total2
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    total2 -= framevalues2(frame - 3)
                    total2 += 30
                    framevalues2(frame - 3) = 30
                    XXbox.Text = total2
                End If
            End If
            strikes2.Add(frame)
        ElseIf n = 3 Then
            total3 -= framevalues3(frame - 1)
            If spares3.Contains(frame - 1) Then
                total3 -= framevalues3(frame - 2)
                total3 += 20
                framevalues3(frame - 2) = 20
                prevbox.Text = total3
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    total3 -= framevalues3(frame - 3)
                    total3 += 30
                    framevalues3(frame - 3) = 30
                    XXbox.Text = total3
                End If
            End If
            strikes3.Add(frame)
        ElseIf n = 4 Then
            total4 -= framevalues4(frame - 1)
            If spares4.Contains(frame - 1) Then
                total4 -= framevalues4(frame - 2)
                total4 += 20
                framevalues4(frame - 2) = 20
                prevbox.Text = total4
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    total4 -= framevalues4(frame - 3)
                    total4 += 30
                    framevalues4(frame - 3) = 30
                    XXbox.Text = total4
                End If
            End If
            strikes4.Add(frame)
        Else
            'This should never happen
        End If
    End Sub

    Private Sub Spare(frame As Integer, v1 As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        Dim frameValue As Integer
        If n = 1 Then
            total1 -= framevalues1(frame - 1)
            If spares1.Contains(frame - 1) Then
                total1 -= framevalues1(frame - 2)
                total1 += 10 + v1
                framevalues1(frame - 2) = 10 + v1
                prevbox.Text = total1
            ElseIf strikes1.Contains(frame - 1) Then
                total1 -= framevalues1(frame - 2)
                If strikes1.Contains(frame - 2) Then
                    total1 -= framevalues1(frame - 3)
                    total1 += 20 + v1
                    framevalues1(frame - 3) = 20 + v1
                    XXbox.Text = total1
                End If
                total1 += 20
                framevalues1(frame - 2) = 20
                prevbox.Text = total1
            End If
            spares1.Add(frame)
        ElseIf n = 2 Then
            total2 -= framevalues2(frame - 1)
            If spares2.Contains(frame - 1) Then
                total2 -= framevalues2(frame - 2)
                total2 += 10 + v1
                framevalues2(frame - 2) = 10 + v1
                prevbox.Text = total2
            ElseIf strikes2.Contains(frame - 1) Then
                total2 -= framevalues2(frame - 2)
                If strikes2.Contains(frame - 2) Then
                    total2 -= framevalues2(frame - 3)
                    total2 += 20 + v1
                    framevalues2(frame - 3) = 20 + v1
                    XXbox.Text = total2
                End If
                total2 += 20
                framevalues2(frame - 2) = 20
                prevbox.Text = total2
            End If
            spares2.Add(frame)
        ElseIf n = 3 Then
            total3 -= framevalues3(frame - 1)
            If spares3.Contains(frame - 1) Then
                total3 -= framevalues3(frame - 2)
                total3 += 10 + v1
                framevalues3(frame - 2) = 10 + v1
                prevbox.Text = total3
            ElseIf strikes3.Contains(frame - 1) Then
                total3 -= framevalues3(frame - 2)
                If strikes3.Contains(frame - 2) Then
                    total3 -= framevalues3(frame - 3)
                    total3 += 20 + v1
                    framevalues3(frame - 3) = 20 + v1
                    XXbox.Text = total3
                End If
                total3 += 20
                framevalues3(frame - 2) = 20
                prevbox.Text = total3
            End If
            spares3.Add(frame)
        ElseIf n = 4 Then
            total4 -= framevalues4(frame - 1)
            If spares4.Contains(frame - 1) Then
                total4 -= framevalues4(frame - 2)
                total4 += 10 + v1
                framevalues4(frame - 2) = 10 + v1
                prevbox.Text = total4
            ElseIf strikes4.Contains(frame - 1) Then
                total4 -= framevalues4(frame - 2)
                If strikes4.Contains(frame - 2) Then
                    total4 -= framevalues4(frame - 3)
                    total4 += 20 + v1
                    framevalues4(frame - 3) = 20 + v1
                    XXbox.Text = total4
                End If
                total4 += 20
                framevalues4(frame - 2) = 20
                prevbox.Text = total4
            End If
            spares4.Add(frame)
        Else
            'this should never happen
        End If
    End Sub

    Private Sub OpenFrame(frame As Integer, v1 As Integer, v2 As Integer,
                          ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        Dim frameValue As Integer
        Dim frameValueX As Integer
        Dim frameValueXX As Integer
        If n = 1 Then
            total1 -= framevalues1(frame - 1)
            If spares1.Contains(frame - 1) Then
                total1 -= framevalues1(frame - 2)
                total1 += 10 + v1
                framevalues1(frame - 2) = 10 + v1
                prevbox.Text = total1
            ElseIf strikes1.Contains(frame - 1) Then
                total1 -= framevalues1(frame - 2)
                If strikes1.Contains(frame - 2) Then
                    total1 -= framevalues1(frame - 3)
                    total1 += 20 + v1
                    framevalues1(frame - 3) = 20 + v1
                    XXbox.Text = total1
                End If
                total1 += 10 + v1 + v2
                framevalues1(frame - 2) = 10 + v1 + v2
                prevbox.Text = total1
            End If
            total1 += v1 + v2
            framevalues1(frame - 1) = v1 + v2
            currentbox.Text = total1
        ElseIf n = 2 Then
            total2 -= framevalues2(frame - 1)
            If spares2.Contains(frame - 1) Then
                total2 -= framevalues2(frame - 2)
                total2 += 10 + v1
                framevalues2(frame - 2) = 10 + v1
                prevbox.Text = total2
            ElseIf strikes2.Contains(frame - 1) Then
                total2 -= framevalues2(frame - 2)
                If strikes2.Contains(frame - 2) Then
                    total2 -= framevalues2(frame - 3)
                    total2 += 20 + v1
                    framevalues2(frame - 3) = 20 + v1
                    XXbox.Text = total2
                End If
                total2 += 10 + v1 + v2
                framevalues2(frame - 2) = 10 + v1 + v2
                prevbox.Text = total2
            End If
            total2 += v1 + v2
            framevalues2(frame - 1) = v1 + v2
            currentbox.Text = total2
        ElseIf n = 3 Then
            total3 -= framevalues3(frame - 1)
            If spares3.Contains(frame - 1) Then
                total3 -= framevalues3(frame - 2)
                total3 += 10 + v1
                framevalues3(frame - 2) = 10 + v1
                prevbox.Text = total3
            ElseIf strikes3.Contains(frame - 1) Then
                total3 -= framevalues3(frame - 2)
                If strikes3.Contains(frame - 2) Then
                    total3 -= framevalues3(frame - 3)
                    total3 += 20 + v1
                    framevalues3(frame - 3) = 20 + v1
                    XXbox.Text = total3
                End If
                total3 += 10 + v1 + v2
                framevalues3(frame - 2) = 10 + v1 + v2
                prevbox.Text = total3
            End If
            total3 += v1 + v2
            framevalues3(frame - 1) = v1 + v2
            currentbox.Text = total3
        ElseIf n = 4 Then
            total4 -= framevalues4(frame - 1)
            If spares4.Contains(frame - 1) Then
                total4 -= framevalues4(frame - 2)
                total4 += 10 + v1
                framevalues4(frame - 2) = 10 + v1
                prevbox.Text = total4
            ElseIf strikes4.Contains(frame - 1) Then
                total4 -= framevalues4(frame - 2)
                If strikes4.Contains(frame - 2) Then
                    total4 -= framevalues4(frame - 3)
                    total4 += 20 + v1
                    framevalues4(frame - 3) = 20 + v1
                    XXbox.Text = total4
                End If
                total4 += 10 + v1 + v2
                framevalues4(frame - 2) = 10 + v1 + v2
                prevbox.Text = total4
            End If
            total4 += v1 + v2
            framevalues4(frame - 1) = v1 + v2
            currentbox.Text = total4
        Else
            'this should never happen
        End If
        
    End Sub

    Private Sub TenthFrame(v1 As Integer, v2 As Integer, v3 As Integer,
                           ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                           ByRef XXbox As TextBox, n As Integer)
        If (v1 + v2 < 10) Then
            OpenFrame(10, v1, v2, currentbox, prevbox, XXbox, n)
        ElseIf (v1 + v2 = 10) Then
            Spare(10, v1, prevbox, XXbox, n)
            If n = 1 Then
                framevalues1(9) = 10 + v3
                total1 += (10 + v3)
                currentbox.Text = total1
            ElseIf n = 2 Then
                framevalues2(9) = 10 + v3
                total2 += (10 + v3)
                currentbox.Text = total2
            ElseIf n = 3 Then
                framevalues3(9) = 10 + v3
                total3 += (10 + v3)
                currentbox.Text = total3
            ElseIf n = 4 Then
                framevalues4(9) = 10 + v3
                total4 += (10 + v3)
                currentbox.Text = total4
            Else
                'this should never happen
            End If
        Else
            Strike(10, prevbox, XXbox, n)
            Strike(11, currentbox, prevbox, n)
            If n = 1 Then
                framevalues1(9) = 10 + v2 + v3
                total1 += (10 + v2 + v3)
                currentbox.Text = total1
            ElseIf n = 2 Then
                framevalues2(9) = 10 + v2 + v3
                total2 += (10 + v2 + v3)
                currentbox.Text = total2
            ElseIf n = 3 Then
                framevalues3(9) = 10 + v2 + v3
                total3 += (10 + v2 + v3)
                currentbox.Text = total3
            ElseIf n = 4 Then
                framevalues4(9) = 10 + v2 + v3
                total4 += (10 + v2 + v3)
                currentbox.Text = total4
            Else
                'this should never happen
            End If
        End If
    End Sub

    Private Sub StrikeRe(frame As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        If n = 1 Then
            If (spares1.Contains(frame - 1)) Then
                total1 -= framevalues1(frame - 2)
                framevalues1(frame - 2) = 20
                total1 += 20
                prevbox.Text = total1
            ElseIf (strikes1.Contains(frame - 1)) Then
                If (strikes1.Contains(frame - 2)) Then
                    total1 -= framevalues1(frame - 3)
                    framevalues1(frame - 3) = 30
                    total1 += 30
                    XXbox.Text = total1
                End If
            End If
            strikes1.Add(frame)
        ElseIf n = 2 Then
            If (spares2.Contains(frame - 1)) Then
                total2 -= framevalues2(frame - 2)
                framevalues2(frame - 2) = 20
                total2 += 20
                prevbox.Text = total2
            ElseIf (strikes2.Contains(frame - 1)) Then
                If (strikes2.Contains(frame - 2)) Then
                    total2 -= framevalues2(frame - 3)
                    framevalues2(frame - 3) = 30
                    total2 += 30
                    XXbox.Text = total2
                End If
            End If
            strikes2.Add(frame)
        ElseIf n = 3 Then
            If (spares3.Contains(frame - 1)) Then
                total3 -= framevalues3(frame - 2)
                framevalues3(frame - 2) = 20
                total3 += 20
                prevbox.Text = total3
            ElseIf (strikes3.Contains(frame - 1)) Then
                If (strikes3.Contains(frame - 2)) Then
                    total3 -= framevalues3(frame - 3)
                    framevalues3(frame - 3) = 30
                    total3 += 30
                    XXbox.Text = total3
                End If
            End If
            strikes3.Add(frame)
        ElseIf n = 4 Then
            If (spares4.Contains(frame - 1)) Then
                total4 -= framevalues4(frame - 2)
                framevalues4(frame - 2) = 20
                total4 += 20
                prevbox.Text = total4
            ElseIf (strikes4.Contains(frame - 1)) Then
                If (strikes4.Contains(frame - 2)) Then
                    total4 -= framevalues4(frame - 3)
                    framevalues4(frame - 3) = 30
                    total4 += 30
                    XXbox.Text = total4
                End If
            End If
            strikes4.Add(frame)
        Else
            'This should never happen
        End If
    End Sub

    Private Sub SpareRe(frame As Integer, v1 As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        Dim frameValue As Integer
        If n = 1 Then
            If (spares1.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total1 -= framevalues1(frame - 2)
                framevalues1(frame - 2) = frameValue
                total1 += frameValue
                prevbox.Text = total1
            ElseIf (strikes1.Contains(frame - 1)) Then
                If (strikes1.Contains(frame - 2)) Then
                    total1 -= framevalues1(frame - 3)
                    framevalues1(frame - 3) = 20 + v1
                    total1 += (20 + v1)
                    XXbox.Text = total1
                End If
                total1 -= framevalues1(frame - 2)
                framevalues1(frame - 2) = 20
                total1 += 20
                prevbox.Text = total1
            End If
            spares1.Add(frame)
        ElseIf n = 2 Then
            If (spares2.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total2 -= framevalues2(frame - 2)
                framevalues2(frame - 2) = frameValue
                total2 += frameValue
                prevbox.Text = total2
            ElseIf (strikes2.Contains(frame - 1)) Then
                If (strikes2.Contains(frame - 2)) Then
                    total2 -= framevalues2(frame - 3)
                    framevalues2(frame - 3) = 20 + v1
                    total2 += (20 + v1)
                    XXbox.Text = total2
                End If
                total2 -= framevalues2(frame - 2)
                framevalues2(frame - 2) = 20
                total2 += 20
                prevbox.Text = total2
            End If
            spares2.Add(frame)
        ElseIf n = 3 Then
            If (spares3.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total3 -= framevalues3(frame - 2)
                framevalues3(frame - 2) = frameValue
                total3 += frameValue
                prevbox.Text = total3
            ElseIf (strikes3.Contains(frame - 1)) Then
                If (strikes3.Contains(frame - 2)) Then
                    total3 -= framevalues3(frame - 3)
                    framevalues3(frame - 3) = 20 + v1
                    total3 += (20 + v1)
                    XXbox.Text = total3
                End If
                total3 -= framevalues3(frame - 2)
                framevalues3(frame - 2) = 20
                total3 += 20
                prevbox.Text = total3
            End If
            spares3.Add(frame)
        ElseIf n = 4 Then
            If (spares4.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total4 -= framevalues4(frame - 2)
                framevalues4(frame - 2) = frameValue
                total4 += frameValue
                prevbox.Text = total4
            ElseIf (strikes4.Contains(frame - 1)) Then
                If (strikes4.Contains(frame - 2)) Then
                    total4 -= framevalues4(frame - 3)
                    framevalues4(frame - 3) = 20 + v1
                    total4 += (20 + v1)
                    XXbox.Text = total4
                End If
                total4 -= framevalues4(frame - 2)
                framevalues4(frame - 2) = 20
                total4 += 20
                prevbox.Text = total4
            End If
            spares4.Add(frame)
        Else
            'this should never happen
        End If
    End Sub

    Private Sub OpenFrameRe(frame As Integer, v1 As Integer, v2 As Integer,
                          ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        Dim frameValue As Integer
        Dim frameValueX As Integer
        Dim frameValueXX As Integer
        If n = 1 Then
            If (spares1.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total1 -= framevalues1(frame - 2)
                framevalues1(frame - 2) = frameValue
                total1 += frameValue
                prevbox.Text = total1
            ElseIf (strikes1.Contains(frame - 1)) Then
                frameValueX = 10 + v1 + v2
                If (strikes1.Contains(frame - 2)) Then
                    frameValueXX = 20 + v1
                    total1 -= framevalues1(frame - 3)
                    framevalues1(frame - 3) = frameValueXX
                    total1 += frameValueXX
                    XXbox.Text = total1
                End If
                total1 -= framevalues1(frame - 2)
                framevalues1(frame - 2) = frameValueX
                total1 += frameValueX
                prevbox.Text = total1
            End If
            total1 -= framevalues1(frame - 1)
            framevalues1(frame - 1) = (v1 + v2)
            total1 += (v1 + v2)
            currentbox.Text = total1
        ElseIf n = 2 Then
            If (spares2.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total2 -= framevalues2(frame - 2)
                framevalues2(frame - 2) = frameValue
                total2 += frameValue
                prevbox.Text = total2
            ElseIf (strikes2.Contains(frame - 1)) Then
                frameValueX = 10 + v1 + v2
                If (strikes2.Contains(frame - 2)) Then
                    frameValueXX = 20 + v1
                    total2 -= framevalues2(frame - 3)
                    framevalues2(frame - 3) = frameValueXX
                    total2 += frameValueXX
                    XXbox.Text = total2
                End If
                total2 -= framevalues2(frame - 2)
                framevalues2(frame - 2) = frameValueX
                total2 += frameValueX
                prevbox.Text = total2
            End If
            total2 -= framevalues2(frame - 1)
            framevalues2(frame - 1) = v1 + v2
            total2 += (v1 + v2)
            currentbox.Text = total2
        ElseIf n = 3 Then
            If (spares3.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total3 -= framevalues3(frame - 2)
                framevalues3(frame - 2) = frameValue
                total3 += frameValue
                prevbox.Text = total3
            ElseIf (strikes3.Contains(frame - 1)) Then
                frameValueX = 10 + v1 + v2
                If (strikes3.Contains(frame - 2)) Then
                    frameValueXX = 20 + v1
                    total3 -= framevalues3(frame - 3)
                    framevalues3(frame - 3) = frameValueXX
                    total3 += frameValueXX
                    XXbox.Text = total3
                End If
                total3 -= framevalues3(frame - 2)
                framevalues3(frame - 2) = frameValueX
                total3 += frameValueX
                prevbox.Text = total3
            End If
            total3 -= framevalues3(frame - 1)
            framevalues3(frame - 1) = v1 + v2
            total3 += (v1 + v2)
            currentbox.Text = total3
        ElseIf n = 4 Then
            If (spares4.Contains(frame - 1)) Then
                frameValue = 10 + v1
                total4 -= framevalues4(frame - 2)
                framevalues4(frame - 2) = frameValue
                total4 += frameValue
                prevbox.Text = total4
            ElseIf (strikes4.Contains(frame - 1)) Then
                frameValueX = 10 + v1 + v2
                If (strikes4.Contains(frame - 2)) Then
                    frameValueXX = 20 + v1
                    total4 -= framevalues4(frame - 3)
                    framevalues4(frame - 3) = frameValueXX
                    total4 += frameValueXX
                    XXbox.Text = total4
                End If
                total4 -= framevalues4(frame - 2)
                framevalues4(frame - 2) = frameValueX
                total4 += frameValueX
                prevbox.Text = total4
            End If
            total4 -= framevalues4(frame - 1)
            framevalues4(frame - 1) = v1 + v2
            total4 += (v1 + v2)
            currentbox.Text = total4
        Else
            'this should never happen
        End If

    End Sub

    Private Sub TenthFrameRe(v1 As Integer, v2 As Integer, v3 As Integer,
                           ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                           ByRef XXbox As TextBox, n As Integer)
        If (v1 + v2 < 10) Then
            OpenFrame(10, v1, v2, currentbox, prevbox, XXbox, n)
        ElseIf (v1 + v2 = 10) Then
            Spare(10, v1, prevbox, XXbox, n)
            If n = 1 Then
                total1 -= framevalues1(9)
                framevalues1(9) = 10 + v3
                total1 += (10 + v3)
                currentbox.Text = total1
            ElseIf n = 2 Then
                total2 -= framevalues2(9)
                framevalues2(9) = 10 + v3
                total2 += (10 + v3)
                currentbox.Text = total2
            ElseIf n = 3 Then
                total3 -= framevalues3(9)
                framevalues3(9) = 10 + v3
                total3 += (10 + v3)
                currentbox.Text = total3
            ElseIf n = 4 Then
                total4 -= framevalues4(9)
                framevalues4(9) = 10 + v3
                total4 += (10 + v3)
                currentbox.Text = total4
            Else
                'this should never happen
            End If
        Else
            Strike(10, prevbox, XXbox, n)
            Strike(11, currentbox, prevbox, n)
            If n = 1 Then
                total1 -= framevalues1(9)
                framevalues1(9) = 10 + v2 + v3
                total1 += (10 + v2 + v3)
                currentbox.Text = total1
            ElseIf n = 2 Then
                total2 -= framevalues2(9)
                framevalues2(9) = 10 + v2 + v3
                total2 += (10 + v2 + v3)
                currentbox.Text = total2
            ElseIf n = 3 Then
                total3 -= framevalues3(9)
                framevalues3(9) = 10 + v2 + v3
                total3 += (10 + v2 + v3)
                currentbox.Text = total3
            ElseIf n = 4 Then
                total4 -= framevalues4(9)
                framevalues4(9) = 10 + v2 + v3
                total4 += (10 + v2 + v3)
                currentbox.Text = total4
            Else
                'this should never happen
            End If
        End If
    End Sub

    Private Sub Striketest(frame As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        'total1 -= framevalues1(frame - 1)
        If spares1.Contains(frame - 1) Then
            framevalues1(frame - 2) = 20
            prevbox.Text = findTotal(frame - 1, n)
        ElseIf strikes1.Contains(frame - 1) Then
            If strikes1.Contains(frame - 2) Then
                framevalues1(frame - 3) = 30
                XXbox.Text = findTotal(frame - 2, n)
            End If
        End If
        strikes1.Add(frame)
    End Sub

    Private Sub Sparetest(frame As Integer, v1 As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        'total1 -= framevalues1(frame - 1)
        If spares1.Contains(frame - 1) Then
            framevalues1(frame - 2) = 10 + v1
            prevbox.Text = findTotal(frame - 1, n)
        ElseIf strikes1.Contains(frame - 1) Then
            If strikes1.Contains(frame - 2) Then
                framevalues1(frame - 3) = 20 + v1
                XXbox.Text = findTotal(frame - 2, n)
            End If
            framevalues1(frame - 2) = 20
            prevbox.Text = findTotal(frame - 1, n)
        End If
        spares1.Add(frame)
    End Sub

    Private Sub OpenFrametest(frame As Integer, v1 As Integer, v2 As Integer,
                          ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        If spares1.Contains(frame - 1) Then
            framevalues1(frame - 2) = 10 + v1
            prevbox.Text = findTotal(frame - 1, n)
        ElseIf strikes1.Contains(frame - 1) Then
            If strikes1.Contains(frame - 2) Then
                framevalues1(frame - 3) = 20 + v1
                XXbox.Text = findTotal(frame - 2, n)
            End If
            framevalues1(frame - 2) = 10 + v1 + v2
            prevbox.Text = findTotal(frame - 1, n)
        End If
        framevalues1(frame - 1) = v1 + v2
        currentbox.Text = findTotal(frame, n)
    End Sub

    Private Sub TenthFrametest(v1 As Integer, v2 As Integer, v3 As Integer,
                           ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                           ByRef XXbox As TextBox, n As Integer)
        If (v1 + v2 < 10) Then
            OpenFrametest(10, v1, v2, currentbox, prevbox, XXbox, n)
        ElseIf (v1 + v2 = 10) Then
            Sparetest(10, v1, prevbox, XXbox, n)
            framevalues1(9) = 10 + v3
            currentbox.Text = findTotal(10, n)
        Else
            Striketest(10, prevbox, XXbox, n)
            Striketest(11, currentbox, prevbox, n)
            framevalues1(9) = 10 + v2 + v3
            currentbox.Text = findTotal(10, n)
        End If
    End Sub

    Private Function findTotal(frame As Integer, n As Integer)
        Dim total As Integer
        If n = 1 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues1(i)
            Next
        ElseIf n = 2 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues2(i)
            Next
        ElseIf n = 3 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues3(i)
            Next
        ElseIf n = 4 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues4(i)
            Next
        Else
            'this should never happen
        End If
        Return total
    End Function

    Private Sub Calculate(ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, frame As Integer, v1 As Integer,
                          v2 As Integer, v3 As Integer, n As Integer)
        If (frame < 10) Then
            If (v1 + v2) < 10 Then
                OpenFrame(frame, v1, v2, currentbox, prevbox, XXbox, n)
            ElseIf v1 = 10 Then
                Strike(frame, prevbox, XXbox, n)
                'currentbox.Text = ""
            Else
                Spare(frame, v1, prevbox, XXbox, n)
                'currentbox.Text = ""
            End If
        Else
            TenthFrame(v1, v2, v3, currentbox, prevbox, XXbox, n)
        End If
    End Sub

    Private Sub Recalculate(ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, frame As Integer, v1 As Integer,
                          v2 As Integer, v3 As Integer, n As Integer)
        If (frame < 10) Then
            If (v1 + v2) < 10 Then
                If strikes1.Contains(frame) Then
                    strikes1.Remove(frame)
                ElseIf spares1.Contains(frame) Then
                    spares1.Remove(frame)
                End If
                OpenFrametest(frame, v1, v2, currentbox, prevbox, XXbox, n)
            ElseIf v1 = 10 Then
                If spares1.Contains(frame) Then
                    spares1.Remove(frame)
                End If
                Striketest(frame, prevbox, XXbox, n)
                currentbox.Text = ""
            Else
                If strikes1.Contains(frame) Then
                    strikes1.Remove(frame)
                End If
                total1 -= framevalues1(frame - 1)
                Sparetest(frame, v1, prevbox, XXbox, n)
                currentbox.Text = ""
            End If
        Else
            TenthFrametest(v1, v2, v3, currentbox, prevbox, XXbox, n)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox111.SelectedIndexChanged
        Dim value As String
        value = ComboBox111.SelectedItem
        If value.Equals("X") Then
            If framevalues1(0) < 0 Then
                Calculate(TextBox11, TextBox11, TextBox11, 1, 10, 0, 0, 1)
            Else
                Recalculate(TextBox11, TextBox11, TextBox11, 1, 10, 0, 0, 1)
            End If
            ComboBox112.Items.Clear()
            ComboBox112.Enabled = False
            ComboBox121.Enabled = True
        Else
            ComboBox112.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox112.Items.Add(i)
            Next
            ComboBox112.Items.Add("/")
            ComboBox112.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox112.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox111.SelectedItem
        value2 = ComboBox112.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(0) < 0 Then
            Calculate(TextBox11, TextBox11, TextBox11, 1, v1, v2, 0, 1)
        Else
            Recalculate(TextBox11, TextBox11, TextBox11, 1, v1, v2, 0, 1)
        End If
        ComboBox121.Enabled = True
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox121.SelectedIndexChanged
        Dim value As String
        value = ComboBox121.SelectedItem
        If value.Equals("X") Then
            If framevalues1(1) < 0 Then
                Calculate(TextBox12, TextBox11, TextBox11, 2, 10, 0, 0, 1)
            Else
                Recalculate(TextBox12, TextBox11, TextBox11, 2, 10, 0, 0, 1)
            End If
            ComboBox122.Items.Clear()
            ComboBox122.Enabled = False
            ComboBox131.Enabled = True
        Else
            ComboBox122.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox122.Items.Add(i)
            Next
            ComboBox122.Items.Add("/")
            ComboBox122.Enabled = True
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox122.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox121.SelectedItem
        value2 = ComboBox122.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(1) < 0 Then
            Calculate(TextBox12, TextBox11, TextBox11, 2, v1, v2, 0, 1)
        Else
            Recalculate(TextBox12, TextBox11, TextBox11, 2, v1, v2, 0, 1)
        End If
        ComboBox131.Enabled = True
    End Sub

    Private Sub ComboBox131_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox131.SelectedIndexChanged
        Dim value As String
        value = ComboBox131.SelectedItem
        If value.Equals("X") Then
            If framevalues1(2) < 0 Then
                Calculate(TextBox13, TextBox12, TextBox11, 3, 10, 0, 0, 1)
            Else
                Recalculate(TextBox13, TextBox12, TextBox11, 3, 10, 0, 0, 1)
            End If
            ComboBox132.Items.Clear()
            ComboBox132.Enabled = False
            ComboBox141.Enabled = True
        Else
            ComboBox132.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox132.Items.Add(i)
            Next
            ComboBox132.Items.Add("/")
            ComboBox132.Enabled = True
        End If
    End Sub

    Private Sub ComboBox132_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox132.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox131.SelectedItem
        value2 = ComboBox132.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(2) < 0 Then
            Calculate(TextBox13, TextBox12, TextBox11, 3, v1, v2, 0, 1)
        Else
            Recalculate(TextBox13, TextBox12, TextBox11, 3, v1, v2, 0, 1)
        End If
        ComboBox141.Enabled = True
    End Sub

    Private Sub ComboBox141_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox141.SelectedIndexChanged
        Dim value As String
        value = ComboBox141.SelectedItem
        If value.Equals("X") Then
            If framevalues1(3) < 0 Then
                Calculate(TextBox14, TextBox13, TextBox12, 4, 10, 0, 0, 1)
            Else
                Recalculate(TextBox14, TextBox13, TextBox12, 4, 10, 0, 0, 1)
            End If
            ComboBox142.Items.Clear()
            ComboBox142.Enabled = False
            ComboBox151.Enabled = True
        Else
            ComboBox142.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox142.Items.Add(i)
            Next
            ComboBox142.Items.Add("/")
            ComboBox142.Enabled = True
        End If
    End Sub

    Private Sub ComboBox142_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox142.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox141.SelectedItem
        value2 = ComboBox142.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(3) < 0 Then
            Calculate(TextBox14, TextBox13, TextBox12, 4, v1, v2, 0, 1)
        Else
            Recalculate(TextBox14, TextBox13, TextBox12, 4, v1, v2, 0, 1)
        End If
        ComboBox151.Enabled = True
    End Sub

    Private Sub ComboBox151_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox151.SelectedIndexChanged
        Dim value As String
        value = ComboBox151.SelectedItem
        If value.Equals("X") Then
            If framevalues1(4) < 0 Then
                Calculate(TextBox15, TextBox14, TextBox13, 5, 10, 0, 0, 1)
            Else
                Recalculate(TextBox15, TextBox14, TextBox13, 5, 10, 0, 0, 1)
            End If
            ComboBox152.Items.Clear()
            ComboBox152.Enabled = False
            ComboBox161.Enabled = True
        Else
            ComboBox152.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox152.Items.Add(i)
            Next
            ComboBox152.Items.Add("/")
            ComboBox152.Enabled = True
        End If
    End Sub

    Private Sub ComboBox152_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox152.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox151.SelectedItem
        value2 = ComboBox152.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(4) < 0 Then
            Calculate(TextBox15, TextBox14, TextBox13, 5, v1, v2, 0, 1)
        Else
            Recalculate(TextBox15, TextBox14, TextBox13, 5, v1, v2, 0, 1)
        End If
        ComboBox161.Enabled = True
    End Sub

    Private Sub ComboBox161_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox161.SelectedIndexChanged
        Dim value As String
        value = ComboBox161.SelectedItem
        If value.Equals("X") Then
            If framevalues1(5) < 0 Then
                Calculate(TextBox16, TextBox15, TextBox14, 6, 10, 0, 0, 1)
            Else
                Recalculate(TextBox16, TextBox15, TextBox14, 6, 10, 0, 0, 1)
            End If
            ComboBox162.Items.Clear()
            ComboBox162.Enabled = False
            ComboBox171.Enabled = True
        Else
            ComboBox162.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox162.Items.Add(i)
            Next
            ComboBox162.Items.Add("/")
            ComboBox162.Enabled = True
        End If
    End Sub

    Private Sub ComboBox162_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox162.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox161.SelectedItem
        value2 = ComboBox162.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(5) < 0 Then
            Calculate(TextBox16, TextBox15, TextBox14, 6, v1, v2, 0, 1)
        Else
            Recalculate(TextBox16, TextBox15, TextBox14, 6, v1, v2, 0, 1)
        End If
        ComboBox171.Enabled = True
    End Sub

    Private Sub ComboBox171_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox171.SelectedIndexChanged
        Dim value As String
        value = ComboBox171.SelectedItem
        If value.Equals("X") Then
            If framevalues1(6) < 0 Then
                Calculate(TextBox17, TextBox16, TextBox15, 7, 10, 0, 0, 1)
            Else
                Recalculate(TextBox17, TextBox16, TextBox15, 7, 10, 0, 0, 1)
            End If
            ComboBox172.Items.Clear()
            ComboBox172.Enabled = False
            ComboBox181.Enabled = True
        Else
            ComboBox172.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox172.Items.Add(i)
            Next
            ComboBox172.Items.Add("/")
            ComboBox172.Enabled = True
        End If
    End Sub

    Private Sub ComboBox172_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox172.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox171.SelectedItem
        value2 = ComboBox172.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(6) < 0 Then
            Calculate(TextBox17, TextBox16, TextBox15, 7, v1, v2, 0, 1)
        Else
            Recalculate(TextBox17, TextBox16, TextBox15, 7, v1, v2, 0, 1)
        End If
        ComboBox181.Enabled = True
    End Sub

    Private Sub ComboBox181_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox181.SelectedIndexChanged
        Dim value As String
        value = ComboBox181.SelectedItem
        If value.Equals("X") Then
            If framevalues1(7) < 0 Then
                Calculate(TextBox18, TextBox17, TextBox16, 8, 10, 0, 0, 1)
            Else
                Recalculate(TextBox18, TextBox17, TextBox16, 8, 10, 0, 0, 1)
            End If
            ComboBox182.Items.Clear()
            ComboBox182.Enabled = False
            ComboBox191.Enabled = True
        Else
            ComboBox182.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox182.Items.Add(i)
            Next
            ComboBox182.Items.Add("/")
            ComboBox182.Enabled = True
        End If
    End Sub

    Private Sub ComboBox182_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox182.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox181.SelectedItem
        value2 = ComboBox182.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(7) < 0 Then
            Calculate(TextBox18, TextBox17, TextBox16, 8, v1, v2, 0, 1)
        Else
            Recalculate(TextBox18, TextBox17, TextBox16, 8, v1, v2, 0, 1)
        End If
        ComboBox191.Enabled = True
    End Sub

    Private Sub ComboBox191_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox191.SelectedIndexChanged
        Dim value As String
        value = ComboBox191.SelectedItem
        If value.Equals("X") Then
            If framevalues1(8) < 0 Then
                Calculate(TextBox19, TextBox18, TextBox17, 9, 10, 0, 0, 1)
            Else
                Recalculate(TextBox19, TextBox18, TextBox17, 9, 10, 0, 0, 1)
            End If
            ComboBox192.Items.Clear()
            ComboBox192.Enabled = False
            ComboBox1101.Enabled = True
        Else
            ComboBox192.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox192.Items.Add(i)
            Next
            ComboBox192.Items.Add("/")
            ComboBox192.Enabled = True
        End If
    End Sub

    Private Sub ComboBox192_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox192.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox191.SelectedItem
        value2 = ComboBox192.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If framevalues1(8) < 0 Then
            Calculate(TextBox19, TextBox18, TextBox17, 9, v1, v2, 0, 1)
        Else
            Recalculate(TextBox19, TextBox18, TextBox17, 9, v1, v2, 0, 1)
        End If
        ComboBox1101.Enabled = True
    End Sub

    Private Sub ComboBox1101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1101.SelectedIndexChanged
        Dim value As String
        value = ComboBox1101.SelectedItem
        If value.Equals("X") Then
            ComboBox1102.Items.Clear()
            For i As Integer = 0 To 9 Step 1
                ComboBox1102.Items.Add(i)
            Next
            ComboBox1102.Items.Add("X")
            ComboBox1102.Enabled = True
        Else
            ComboBox1102.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox1102.Items.Add(i)
            Next
            ComboBox1102.Items.Add("/")
            ComboBox1102.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox1101.SelectedItem
        value2 = ComboBox1102.SelectedItem
        If value1.Equals("X") Then
            ComboBox1103.Enabled = True
        Else
            If value2.Equals("/") Then
                ComboBox1103.Enabled = True
            Else
                ComboBox1103.Enabled = False
                If framevalues1(9) < 0 Then
                    Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, 0, 1)
                Else
                    Recalculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, 0, 1)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox1101.SelectedItem
        value2 = ComboBox1102.SelectedItem
        value3 = ComboBox1103.SelectedItem
        If value1.Equals("X") Then
            v1 = 10
        Else
            v1 = CInt(value1)
        End If
        If value2.Equals("X") Then
            v2 = 10
        ElseIf value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If value3.Equals("X") Then
            v3 = 10
        Else
            v3 = CInt(value3)
        End If
        If framevalues1(9) < 0 Then
            Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, v3, 1)
        Else
            Recalculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, v3, 1)
        End If
    End Sub

    Private Sub ComboBox211_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox211.SelectedIndexChanged
        Dim value As String
        value = ComboBox211.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox21, TextBox21, TextBox21, 1, 10, 0, 0, 2)
            ComboBox212.Items.Clear()
            ComboBox212.Enabled = False
            ComboBox221.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox212.Enabled = True
        Else
            ComboBox212.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox212.Items.Add(i)
            Next
            ComboBox212.Items.Add("/")
            ComboBox212.Enabled = True
        End If
    End Sub

    Private Sub ComboBox212_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox212.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox211.SelectedItem
        value2 = ComboBox212.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox21, TextBox21, TextBox21, 1, v1, v2, 0, 2)
        ComboBox221.Enabled = True
    End Sub

    Private Sub ComboBox221_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox221.SelectedIndexChanged
        Dim value As String
        value = ComboBox221.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox22, TextBox21, TextBox21, 2, 10, 0, 0, 2)
            ComboBox222.Items.Clear()
            ComboBox222.Enabled = False
            ComboBox231.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox222.Enabled = True
        Else
            ComboBox222.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox222.Items.Add(i)
            Next
            ComboBox222.Items.Add("/")
            ComboBox222.Enabled = True
        End If
    End Sub

    Private Sub ComboBox222_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox222.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox221.SelectedItem
        value2 = ComboBox222.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox22, TextBox21, TextBox21, 2, v1, v2, 0, 2)
        ComboBox231.Enabled = True
    End Sub

    Private Sub ComboBox231_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox231.SelectedIndexChanged
        Dim value As String
        value = ComboBox231.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox23, TextBox22, TextBox21, 3, 10, 0, 0, 2)
            ComboBox232.Items.Clear()
            ComboBox232.Enabled = False
            ComboBox241.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox232.Enabled = True
        Else
            ComboBox232.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox232.Items.Add(i)
            Next
            ComboBox232.Items.Add("/")
            ComboBox232.Enabled = True
        End If
    End Sub

    Private Sub ComboBox232_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox232.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox231.SelectedItem
        value2 = ComboBox232.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox23, TextBox22, TextBox21, 3, v1, v2, 0, 2)
        ComboBox241.Enabled = True
    End Sub

    Private Sub ComboBox241_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox241.SelectedIndexChanged
        Dim value As String
        value = ComboBox241.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox24, TextBox23, TextBox22, 4, 10, 0, 0, 2)
            ComboBox242.Items.Clear()
            ComboBox242.Enabled = False
            ComboBox251.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox242.Enabled = True
        Else
            ComboBox242.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox242.Items.Add(i)
            Next
            ComboBox242.Items.Add("/")
            ComboBox242.Enabled = True
        End If
    End Sub

    Private Sub ComboBox242_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox242.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox241.SelectedItem
        value2 = ComboBox242.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox24, TextBox23, TextBox22, 4, v1, v2, 0, 2)
        ComboBox251.Enabled = True
    End Sub

    Private Sub ComboBox251_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox251.SelectedIndexChanged
        Dim value As String
        value = ComboBox251.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox25, TextBox24, TextBox23, 5, 10, 0, 0, 2)
            ComboBox252.Items.Clear()
            ComboBox252.Enabled = False
            ComboBox261.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox252.Enabled = True
        Else
            ComboBox252.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox252.Items.Add(i)
            Next
            ComboBox252.Items.Add("/")
            ComboBox252.Enabled = True
        End If
    End Sub

    Private Sub ComboBox252_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox252.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox251.SelectedItem
        value2 = ComboBox252.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox25, TextBox24, TextBox23, 5, v1, v2, 0, 2)
        ComboBox261.Enabled = True
    End Sub

    Private Sub ComboBox261_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox261.SelectedIndexChanged
        Dim value As String
        value = ComboBox261.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox26, TextBox25, TextBox24, 6, 10, 0, 0, 2)
            ComboBox262.Items.Clear()
            ComboBox262.Enabled = False
            ComboBox271.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox262.Enabled = True
        Else
            ComboBox262.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox262.Items.Add(i)
            Next
            ComboBox262.Items.Add("/")
            ComboBox262.Enabled = True
        End If
    End Sub

    Private Sub ComboBox262_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox262.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox261.SelectedItem
        value2 = ComboBox262.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox26, TextBox25, TextBox24, 6, v1, v2, 0, 2)
        ComboBox271.Enabled = True
    End Sub

    Private Sub ComboBox271_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox271.SelectedIndexChanged
        Dim value As String
        value = ComboBox271.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox27, TextBox26, TextBox25, 7, 10, 0, 0, 2)
            ComboBox272.Items.Clear()
            ComboBox272.Enabled = False
            ComboBox281.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox272.Enabled = True
        Else
            ComboBox272.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox272.Items.Add(i)
            Next
            ComboBox272.Items.Add("/")
            ComboBox272.Enabled = True
        End If
    End Sub

    Private Sub ComboBox272_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox272.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox271.SelectedItem
        value2 = ComboBox272.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox27, TextBox26, TextBox25, 7, v1, v2, 0, 2)
        ComboBox281.Enabled = True
    End Sub

    Private Sub ComboBox281_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox281.SelectedIndexChanged
        Dim value As String
        value = ComboBox281.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox28, TextBox27, TextBox26, 8, 10, 0, 0, 2)
            ComboBox282.Items.Clear()
            ComboBox282.Enabled = False
            ComboBox291.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox282.Enabled = True
        Else
            ComboBox282.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox282.Items.Add(i)
            Next
            ComboBox282.Items.Add("/")
            ComboBox282.Enabled = True
        End If
    End Sub

    Private Sub ComboBox282_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox282.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox281.SelectedItem
        value2 = ComboBox282.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox28, TextBox27, TextBox26, 8, v1, v2, 0, 2)
        ComboBox291.Enabled = True
    End Sub

    Private Sub ComboBox291_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox291.SelectedIndexChanged
        Dim value As String
        value = ComboBox291.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox29, TextBox28, TextBox27, 9, 10, 0, 0, 2)
            ComboBox292.Items.Clear()
            ComboBox292.Enabled = False
            ComboBox2101.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox292.Enabled = True
        Else
            ComboBox292.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox292.Items.Add(i)
            Next
            ComboBox292.Items.Add("/")
            ComboBox292.Enabled = True
        End If
    End Sub

    Private Sub ComboBox292_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox292.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox291.SelectedItem
        value2 = ComboBox292.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox29, TextBox28, TextBox27, 9, v1, v2, 0, 2)
        ComboBox2101.Enabled = True
    End Sub

    Private Sub ComboBox2101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2101.SelectedIndexChanged
        Dim value As String
        value = ComboBox2101.SelectedItem
        If value.Equals("X") Then
            ComboBox2102.Items.Clear()
            For i As Integer = 0 To 9 Step 1
                ComboBox2102.Items.Add(i)
            Next
            ComboBox2102.Items.Add("X")
            ComboBox2101.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox2102.Enabled = True
        Else
            ComboBox2102.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox2102.Items.Add(i)
            Next
            ComboBox2102.Items.Add("/")
            ComboBox2102.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox2101.SelectedItem
        value2 = ComboBox2102.SelectedItem
        If value1.Equals("X") Then
            ComboBox2103.Enabled = True
        Else
            If value2.Equals("/") Then
                ComboBox2103.Enabled = True
            Else
                ComboBox2103.Enabled = False
                If framevalues1(9) < 0 Then
                    Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, 0, 1)
                Else
                    Recalculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, 0, 1)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox2103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox2101.SelectedItem
        value2 = ComboBox2102.SelectedItem
        value3 = ComboBox2103.SelectedItem
        If value1.Equals("X") Then
            v1 = 10
        Else
            v1 = CInt(value1)
        End If
        If value2.Equals("X") Then
            v2 = 10
        ElseIf value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If value3.Equals("X") Then
            v3 = 10
        Else
            v3 = CInt(value3)
        End If
        If framevalues1(9) < 0 Then
            Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, v3, 1)
        Else
            Recalculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, v3, 1)
        End If
    End Sub

    Private Sub ComboBox311_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox311.SelectedIndexChanged
        Dim value As String
        value = ComboBox311.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox31, TextBox31, TextBox31, 1, 10, 0, 0, 3)
            ComboBox312.Items.Clear()
            ComboBox312.Enabled = False
            ComboBox321.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox312.Enabled = True
        Else
            ComboBox312.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox312.Items.Add(i)
            Next
            ComboBox312.Items.Add("/")
            ComboBox312.Enabled = True
        End If
    End Sub

    Private Sub ComboBox312_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox312.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox311.SelectedItem
        value2 = ComboBox312.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox31, TextBox31, TextBox31, 1, v1, v2, 0, 3)
        ComboBox321.Enabled = True
    End Sub

    Private Sub ComboBox321_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox321.SelectedIndexChanged
        Dim value As String
        value = ComboBox321.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox32, TextBox31, TextBox31, 2, 10, 0, 0, 3)
            ComboBox322.Items.Clear()
            ComboBox322.Enabled = False
            ComboBox331.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox322.Enabled = True
        Else
            ComboBox322.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox322.Items.Add(i)
            Next
            ComboBox322.Items.Add("/")
            ComboBox322.Enabled = True
        End If
    End Sub

    Private Sub ComboBox322_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox322.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox321.SelectedItem
        value2 = ComboBox322.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox32, TextBox31, TextBox31, 2, v1, v2, 0, 3)
        ComboBox331.Enabled = True
    End Sub

    Private Sub ComboBox331_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox331.SelectedIndexChanged
        Dim value As String
        value = ComboBox331.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox33, TextBox32, TextBox31, 3, 10, 0, 0, 3)
            ComboBox332.Items.Clear()
            ComboBox332.Enabled = False
            ComboBox341.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox332.Enabled = True
        Else
            ComboBox332.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox332.Items.Add(i)
            Next
            ComboBox332.Items.Add("/")
            ComboBox332.Enabled = True
        End If
    End Sub

    Private Sub ComboBox332_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox332.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox331.SelectedItem
        value2 = ComboBox332.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox33, TextBox32, TextBox31, 3, v1, v2, 0, 3)
        ComboBox341.Enabled = True
    End Sub

    Private Sub ComboBox341_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox341.SelectedIndexChanged
        Dim value As String
        value = ComboBox341.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox34, TextBox33, TextBox32, 4, 10, 0, 0, 3)
            ComboBox342.Items.Clear()
            ComboBox342.Enabled = False
            ComboBox351.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox342.Enabled = True
        Else
            ComboBox342.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox342.Items.Add(i)
            Next
            ComboBox342.Items.Add("/")
            ComboBox342.Enabled = True
        End If
    End Sub

    Private Sub ComboBox342_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox342.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox341.SelectedItem
        value2 = ComboBox342.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox34, TextBox33, TextBox32, 4, v1, v2, 0, 3)
        ComboBox351.Enabled = True
    End Sub

    Private Sub ComboBox351_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox351.SelectedIndexChanged
        Dim value As String
        value = ComboBox351.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox35, TextBox34, TextBox33, 5, 10, 0, 0, 3)
            ComboBox352.Items.Clear()
            ComboBox352.Enabled = False
            ComboBox361.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox352.Enabled = True
        Else
            ComboBox352.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox352.Items.Add(i)
            Next
            ComboBox352.Items.Add("/")
            ComboBox352.Enabled = True
        End If
    End Sub

    Private Sub ComboBox352_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox352.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox351.SelectedItem
        value2 = ComboBox352.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox35, TextBox34, TextBox33, 5, v1, v2, 0, 3)
        ComboBox361.Enabled = True
    End Sub

    Private Sub ComboBox361_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox361.SelectedIndexChanged
        Dim value As String
        value = ComboBox361.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox36, TextBox35, TextBox34, 6, 10, 0, 0, 3)
            ComboBox362.Items.Clear()
            ComboBox362.Enabled = False
            ComboBox371.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox362.Enabled = True
        Else
            ComboBox362.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox362.Items.Add(i)
            Next
            ComboBox362.Items.Add("/")
            ComboBox362.Enabled = True
        End If
    End Sub

    Private Sub ComboBox362_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox362.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox361.SelectedItem
        value2 = ComboBox362.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox36, TextBox35, TextBox34, 6, v1, v2, 0, 3)
        ComboBox371.Enabled = True
    End Sub

    Private Sub ComboBox371_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox371.SelectedIndexChanged
        Dim value As String
        value = ComboBox371.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox37, TextBox36, TextBox35, 7, 10, 0, 0, 3)
            ComboBox372.Items.Clear()
            ComboBox372.Enabled = False
            ComboBox381.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox372.Enabled = True
        Else
            ComboBox372.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox372.Items.Add(i)
            Next
            ComboBox372.Items.Add("/")
            ComboBox372.Enabled = True
        End If
    End Sub

    Private Sub ComboBox372_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox372.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox371.SelectedItem
        value2 = ComboBox372.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox37, TextBox36, TextBox35, 7, v1, v2, 0, 3)
        ComboBox381.Enabled = True
    End Sub

    Private Sub ComboBox381_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox381.SelectedIndexChanged
        Dim value As String
        value = ComboBox381.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox38, TextBox37, TextBox36, 8, 10, 0, 0, 3)
            ComboBox382.Items.Clear()
            ComboBox382.Enabled = False
            ComboBox391.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox382.Enabled = True
        Else
            ComboBox382.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox382.Items.Add(i)
            Next
            ComboBox382.Items.Add("/")
            ComboBox382.Enabled = True
        End If
    End Sub

    Private Sub ComboBox382_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox382.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox381.SelectedItem
        value2 = ComboBox382.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox38, TextBox37, TextBox36, 8, v1, v2, 0, 3)
        ComboBox391.Enabled = True
    End Sub

    Private Sub ComboBox391_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox391.SelectedIndexChanged
        Dim value As String
        value = ComboBox391.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox39, TextBox38, TextBox37, 9, 10, 0, 0, 3)
            ComboBox392.Items.Clear()
            ComboBox392.Enabled = False
            ComboBox3101.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox392.Enabled = True
        Else
            ComboBox392.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox392.Items.Add(i)
            Next
            ComboBox392.Items.Add("/")
            ComboBox392.Enabled = True
        End If
    End Sub

    Private Sub ComboBox392_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox392.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox391.SelectedItem
        value2 = ComboBox392.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox39, TextBox38, TextBox37, 9, v1, v2, 0, 3)
        ComboBox3101.Enabled = True
    End Sub

    Private Sub ComboBox3101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3101.SelectedIndexChanged
        Dim value As String
        value = ComboBox3101.SelectedItem
        If value.Equals("X") Then
            ComboBox3102.Items.Clear()
            For i As Integer = 0 To 9 Step 1
                ComboBox3102.Items.Add(i)
            Next
            ComboBox3102.Items.Add("X")
            ComboBox3102.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox3102.Enabled = True
        Else
            ComboBox3102.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox3102.Items.Add(i)
            Next
            ComboBox3102.Items.Add("/")
            ComboBox3102.Enabled = True
        End If
    End Sub

    Private Sub ComboBox3102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox3101.SelectedItem
        value2 = ComboBox3102.SelectedItem
        If value1.Equals("X") Then
            ComboBox3103.Enabled = True
        Else
            If value2.Equals("/") Then
                ComboBox3103.Enabled = True
            Else
                ComboBox3103.Enabled = False
                If framevalues1(9) < 0 Then
                    Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, 0, 1)
                Else
                    Recalculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, 0, 1)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox3103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox3101.SelectedItem
        value2 = ComboBox3102.SelectedItem
        value3 = ComboBox3103.SelectedItem
        If value1.Equals("X") Then
            v1 = 10
        Else
            v1 = CInt(value1)
        End If
        If value2.Equals("X") Then
            v2 = 10
        ElseIf value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If value3.Equals("X") Then
            v3 = 10
        Else
            v3 = CInt(value3)
        End If
        If framevalues1(9) < 0 Then
            Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, v3, 1)
        Else
            Recalculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, v3, 1)
        End If
    End Sub

    Private Sub ComboBox411_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox411.SelectedIndexChanged
        Dim value As String
        value = ComboBox411.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox41, TextBox41, TextBox41, 1, 10, 0, 0, 4)
            ComboBox412.Items.Clear()
            ComboBox412.Enabled = False
            ComboBox421.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox412.Enabled = True
        Else
            ComboBox412.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox412.Items.Add(i)
            Next
            ComboBox412.Items.Add("/")
            ComboBox412.Enabled = True
        End If
    End Sub

    Private Sub ComboBox412_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox412.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox411.SelectedItem
        value2 = ComboBox412.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox41, TextBox41, TextBox41, 1, v1, v2, 0, 4)
        ComboBox421.Enabled = True
    End Sub

    Private Sub ComboBox421_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox421.SelectedIndexChanged
        Dim value As String
        value = ComboBox421.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox42, TextBox41, TextBox41, 2, 10, 0, 0, 4)
            ComboBox422.Items.Clear()
            ComboBox422.Enabled = False
            ComboBox431.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox422.Enabled = True
        Else
            ComboBox422.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox422.Items.Add(i)
            Next
            ComboBox422.Items.Add("/")
            ComboBox422.Enabled = True
        End If
    End Sub

    Private Sub ComboBox422_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox422.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox421.SelectedItem
        value2 = ComboBox422.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox42, TextBox41, TextBox41, 2, v1, v2, 0, 4)
        ComboBox431.Enabled = True
    End Sub

    Private Sub ComboBox431_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox431.SelectedIndexChanged
        Dim value As String
        value = ComboBox431.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox43, TextBox42, TextBox41, 3, 10, 0, 0, 4)
            ComboBox432.Items.Clear()
            ComboBox432.Enabled = False
            ComboBox441.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox432.Enabled = True
        Else
            ComboBox432.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox432.Items.Add(i)
            Next
            ComboBox432.Items.Add("/")
            ComboBox432.Enabled = True
        End If
    End Sub

    Private Sub ComboBox432_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox432.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox431.SelectedItem
        value2 = ComboBox432.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox43, TextBox42, TextBox41, 3, v1, v2, 0, 4)
        ComboBox441.Enabled = True
    End Sub

    Private Sub ComboBox441_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox441.SelectedIndexChanged
        Dim value As String
        value = ComboBox441.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox44, TextBox43, TextBox42, 4, 10, 0, 0, 4)
            ComboBox442.Items.Clear()
            ComboBox442.Enabled = False
            ComboBox451.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox442.Enabled = True
        Else
            ComboBox442.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox442.Items.Add(i)
            Next
            ComboBox442.Items.Add("/")
            ComboBox442.Enabled = True
        End If
    End Sub

    Private Sub ComboBox442_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox442.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox441.SelectedItem
        value2 = ComboBox442.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox44, TextBox43, TextBox42, 4, v1, v2, 0, 4)
        ComboBox451.Enabled = True
    End Sub

    Private Sub ComboBox451_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox451.SelectedIndexChanged
        Dim value As String
        value = ComboBox451.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox45, TextBox44, TextBox43, 5, 10, 0, 0, 4)
            ComboBox452.Items.Clear()
            ComboBox452.Enabled = False
            ComboBox461.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox452.Enabled = True
        Else
            ComboBox452.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox452.Items.Add(i)
            Next
            ComboBox452.Items.Add("/")
            ComboBox452.Enabled = True
        End If
    End Sub

    Private Sub ComboBox452_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox452.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox451.SelectedItem
        value2 = ComboBox452.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox45, TextBox44, TextBox43, 5, v1, v2, 0, 4)
        ComboBox461.Enabled = True
    End Sub

    Private Sub ComboBox461_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox461.SelectedIndexChanged
        Dim value As String
        value = ComboBox461.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox46, TextBox45, TextBox44, 6, 10, 0, 0, 4)
            ComboBox462.Items.Clear()
            ComboBox462.Enabled = False
            ComboBox471.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox462.Enabled = True
        Else
            ComboBox462.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox462.Items.Add(i)
            Next
            ComboBox462.Items.Add("/")
            ComboBox462.Enabled = True
        End If
    End Sub

    Private Sub ComboBox462_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox462.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox461.SelectedItem
        value2 = ComboBox462.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox46, TextBox45, TextBox44, 6, v1, v2, 0, 4)
        ComboBox471.Enabled = True
    End Sub

    Private Sub ComboBox471_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox471.SelectedIndexChanged
        Dim value As String
        value = ComboBox471.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox47, TextBox46, TextBox45, 7, 10, 0, 0, 4)
            ComboBox472.Items.Clear()
            ComboBox472.Enabled = False
            ComboBox481.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox472.Enabled = True
        Else
            ComboBox472.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox472.Items.Add(i)
            Next
            ComboBox472.Items.Add("/")
            ComboBox472.Enabled = True
        End If
    End Sub

    Private Sub ComboBox472_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox472.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox471.SelectedItem
        value2 = ComboBox472.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox47, TextBox46, TextBox45, 7, v1, v2, 0, 4)
        ComboBox481.Enabled = True
    End Sub

    Private Sub ComboBox481_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox481.SelectedIndexChanged
        Dim value As String
        value = ComboBox481.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox48, TextBox47, TextBox46, 8, 10, 0, 0, 4)
            ComboBox482.Items.Clear()
            ComboBox482.Enabled = False
            ComboBox491.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox482.Enabled = True
        Else
            ComboBox482.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox482.Items.Add(i)
            Next
            ComboBox482.Items.Add("/")
            ComboBox482.Enabled = True
        End If
    End Sub

    Private Sub ComboBox482_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox482.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox481.SelectedItem
        value2 = ComboBox482.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox48, TextBox47, TextBox46, 8, v1, v2, 0, 4)
        ComboBox491.Enabled = True
    End Sub

    Private Sub ComboBox491_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox491.SelectedIndexChanged
        Dim value As String
        value = ComboBox491.SelectedItem
        If value.Equals("X") Then
            Calculate(TextBox49, TextBox48, TextBox47, 9, 10, 0, 0, 4)
            ComboBox492.Items.Clear()
            ComboBox492.Enabled = False
            ComboBox4101.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox492.Enabled = True
        Else
            ComboBox492.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox492.Items.Add(i)
            Next
            ComboBox492.Items.Add("/")
            ComboBox492.Enabled = True
        End If
    End Sub

    Private Sub ComboBox492_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox492.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox491.SelectedItem
        value2 = ComboBox492.SelectedItem
        If value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        Calculate(TextBox49, TextBox48, TextBox47, 9, v1, v2, 0, 4)
        ComboBox4101.Enabled = True
    End Sub

    Private Sub ComboBox4101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4101.SelectedIndexChanged
        Dim value As String
        value = ComboBox4101.SelectedItem
        If value.Equals("X") Then
            ComboBox4102.Items.Clear()
            For i As Integer = 0 To 9 Step 1
                ComboBox4102.Items.Add(i)
            Next
            ComboBox4102.Items.Add("X")
            ComboBox4102.Enabled = True
        ElseIf value.Equals("0") Then
            ComboBox4102.Enabled = True
        Else
            ComboBox4102.Items.Clear()
            For i As Integer = 0 To (9 - value) Step 1
                ComboBox4102.Items.Add(i)
            Next
            ComboBox4102.Items.Add("/")
            ComboBox4102.Enabled = True
        End If
    End Sub

    Private Sub ComboBox4102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox4101.SelectedItem
        value2 = ComboBox4102.SelectedItem
        If value1.Equals("X") Then
            ComboBox4103.Enabled = True
        Else
            If value2.Equals("/") Then
                ComboBox4103.Enabled = True
            Else
                ComboBox4103.Enabled = False
                If framevalues1(9) < 0 Then
                    Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, 0, 1)
                Else
                    Recalculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, 0, 1)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox4103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox4101.SelectedItem
        value2 = ComboBox4102.SelectedItem
        value3 = ComboBox4103.SelectedItem
        If value1.Equals("X") Then
            v1 = 10
        Else
            v1 = CInt(value1)
        End If
        If value2.Equals("X") Then
            v2 = 10
        ElseIf value2.Equals("/") Then
            v2 = 10 - v1
        Else
            v2 = CInt(value2)
        End If
        If value3.Equals("X") Then
            v3 = 10
        Else
            v3 = CInt(value3)
        End If
        If framevalues1(9) < 0 Then
            Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, v3, 1)
        Else
            Recalculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, v3, 1)
        End If
    End Sub

End Class

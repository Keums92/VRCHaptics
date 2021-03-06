﻿Public Class DeviceEditor
    Private Sub BTNApply_Click(sender As Object, e As EventArgs) Handles BTNApply.Click
        If Form1.DeviceMethod = 1 Then
            Form1.NodeDeviceNames.Add(TextBox1.Text)
            Form1.NodeDeviceConnection.Add(0)
            Form1.NodeOutputs.Add(New List(Of Boolean))
            For i = 0 To NumericUpDown1.Value - 1
                Form1.NodeOutputs(Form1.NodeOutputs.Count - 1).Add(False)
            Next
            Form1.NodeRootBone.Add(New List(Of Integer))
            Form1.NodeActivationDistance.Add(New List(Of Single))
            Form1.NodeBoneOffset.Add(New List(Of OpenTK.Vector3))
            Form1.NodeFinalPos.Add(New List(Of OpenTK.Vector3))
            For i = 0 To NumericUpDown1.Value - 1
                Form1.NodeRootBone(Form1.NodeDeviceNames.Count - 1).Add(0)
                Form1.NodeActivationDistance(Form1.NodeDeviceNames.Count - 1).Add(0.05)
                Form1.NodeBoneOffset(Form1.NodeDeviceNames.Count - 1).Add(New OpenTK.Vector3(0, 0, 0))
                Form1.NodeFinalPos(Form1.NodeDeviceNames.Count - 1).Add(New OpenTK.Vector3(0, 0, 0))
            Next

            Form1.DGVDevice.Rows.Add()
            Form1.DGVDevice.Rows(Form1.DGVDevice.Rows.Count - 1).Cells(0).Value = Form1.NodeDeviceNames.Count
            Form1.DGVDevice.Rows(Form1.DGVDevice.Rows.Count - 1).Cells(1).Value = Form1.NodeDeviceNames(Form1.NodeDeviceNames.Count - 1)
            Form1.DGVNodeUpdate()
            Me.Close()
        ElseIf Form1.DeviceMethod = 2 Then
            Form1.NodeDeviceNames(Form1.DeviceIndex) = TextBox1.Text
            'Form1.NodeDeviceConnection(Form1.DeviceIndex) = TextBox2.Text
            If NumericUpDown1.Value > Form1.NodeOutputs(Form1.DeviceIndex).Count Then
                For i = Form1.NodeOutputs(Form1.DeviceIndex).Count To NumericUpDown1.Value - 1
                    Form1.NodeRootBone(Form1.DeviceIndex).Add(0)
                    Form1.NodeOutputs(Form1.DeviceIndex).Add(False)
                    Form1.NodeActivationDistance(Form1.NodeDeviceNames.Count - 1).Add(0.05)
                    Form1.NodeBoneOffset(Form1.DeviceIndex).Add(New OpenTK.Vector3(0, 0, 0))
                    Form1.NodeFinalPos(Form1.DeviceIndex).Add(New OpenTK.Vector3(0, 0, 0))
                Next
            ElseIf NumericUpDown1.Value < Form1.NodeOutputs(Form1.DeviceIndex).count Then
                Dim difference As Integer = Form1.NodeOutputs(Form1.DeviceIndex).Count - NumericUpDown1.Value
                For i = 1 To difference
                    Form1.NodeRootBone(Form1.DeviceIndex).RemoveAt(Form1.NodeRootBone(Form1.DeviceIndex).Count - 1)
                    Form1.NodeActivationDistance(Form1.DeviceIndex).RemoveAt(Form1.NodeActivationDistance(Form1.DeviceIndex).Count - 1)
                    Form1.NodeBoneOffset(Form1.DeviceIndex).RemoveAt(Form1.NodeBoneOffset(Form1.DeviceIndex).Count - 1)
                    Form1.NodeFinalPos(Form1.DeviceIndex).RemoveAt(Form1.NodeFinalPos(Form1.DeviceIndex).Count - 1)
                    Form1.NodeOutputs(Form1.DeviceIndex).Remove(0)
                Next
            End If
            Form1.DGVDevicesUpdate()
            Form1.DGVNodeUpdate()

            Form1.Settingschanged = True
            Me.Close()
        End If
    End Sub

    Private Sub BTNCancel_Click(sender As Object, e As EventArgs) Handles BTNCancel.Click
        Me.Close()
    End Sub

    Private Sub DeviceEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.DeviceMethod = 1 Then
            TextBox1.Text = ""
            'TextBox2.Text = ""
            NumericUpDown1.Value = 0
        ElseIf Form1.DeviceMethod = 2 Then
            TextBox1.Text = Form1.NodeDeviceNames(Form1.DeviceIndex)
            'TextBox2.Text = Form1.NodeDeviceConnection(Form1.DeviceIndex)
            NumericUpDown1.Value = Form1.NodeOutputs(Form1.DeviceIndex).Count
        End If
    End Sub
End Class
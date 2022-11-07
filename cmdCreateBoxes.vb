'Program:  CreateBoxes_addin
'Owner: National Park Service Geologic Resources Inventory
'Developed by: Original coding by James Chappell,
'              converted to ESRI add-in by Heather Stanton
'Upgraded to work with ArcGIS 10.4.1: 1/18/2017 (J. Chappell)
'Description: Creates a grid, based on user input and selected layer
'             for extent, in the default graphics layer of the ArcMap
'             document (mxd).  Users can alter and/or delete all cells
'             or individual cells using the Draw toolbar in ArcMap.
'             This tool is useful for creating workflow and tracking
'             capture and qc tasks.
'

Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.esriSystem
Imports System.Windows.Forms

Public Class cmdCreateBoxes
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()

        'Get dockable window.
        Dim dockWinID As UID = New UID()
        dockWinID.Value = "CSU-NPS_createBoxes_addin_frmCreateBoxes"
        Dim dockWindow As DockableWindow
        dockWindow = My.ArcMap.DockableWindowManager.GetDockableWindow(dockWinID)
        dockWindow.Dock(False)
        dockWindow.Show(True)

        My.ArcMap.Application.CurrentTool = Nothing
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub

End Class

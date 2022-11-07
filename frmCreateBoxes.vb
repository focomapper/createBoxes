'Program:  CreateBoxes_addin
'Owner: National Park Service Geologic Resources Inventory
'Developed by: Original coding by James Chappell,
'              converted to ESRI add-in by Heather Stanton
'Description: Creates a grid, based on user input and selected layer
'             for extent, in the default graphics layer of the ArcMap
'             document (mxd).  Users can alter and/or delete all cells
'             or individual cells using the Draw toolbar in ArcMap.
'             This tool is useful for creating workflow and tracking
'             capture and qc tasks.
'
' <summary>
' Designer class of the dockable window add-in. It contains user interfaces that
' make up the dockable window.
' </summary>
'
Imports System.Runtime.InteropServices
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Display
Public Class frmCreateBoxes
    Dim pMxDoc As IMxDocument
    Dim pGraphicsCont As IGraphicsContainer
    Dim pGrfxCont As IGraphicsContainer
    Dim mColor As IColor
    Public Sub New(ByVal hook As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Hook = hook
    End Sub


    Private m_hook As Object
    ''' <summary>
    ''' Host object of the dockable window
    ''' </summary> 
    Public Property Hook() As Object
        Get
            Return m_hook
        End Get
        Set(ByVal value As Object)
            m_hook = value
        End Set
    End Property

    ''' <summary>
    ''' Implementation class of the dockable window add-in. It is responsible for
    ''' creating and disposing the user interface class for the dockable window.
    ''' </summary>
    Public Class AddinImpl
        Inherits ESRI.ArcGIS.Desktop.AddIns.DockableWindow

        Private m_windowUI As frmCreateBoxes

        Protected Overrides Function OnCreateChild() As System.IntPtr
            m_windowUI = New frmCreateBoxes(Me.Hook)
            Return m_windowUI.Handle
        End Function

        Protected Overrides Sub Dispose(ByVal Param As Boolean)
            If m_windowUI IsNot Nothing Then
                m_windowUI.Dispose(Param)
            End If

            MyBase.Dispose(Param)
        End Sub

    End Class
    Private Sub bExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bExecute.Click

        pMxDoc = My.ThisApplication.Document

        'get a layer from toc -- later will have to point to glg featureclass
        Dim pLayer As ILayer
        pLayer = pMxDoc.SelectedLayer

        'get extent from layer
        Dim pGeoDataset As IGeoDataset

        'Set pGeoDataset = pFeatureclass
        pGeoDataset = pLayer

        'set envelope to featureclass extent
        Dim pEnv As IEnvelope

        If pLayer Is Nothing Then
            MsgBox("Please select a feature layer")
            Exit Sub
        End If

        If Not TypeOf pLayer Is IFeatureLayer Then
            MsgBox("Please select a feature layer")
            Exit Sub
        End If

        pEnv = pGeoDataset.Extent

        'point element to envelope -- change to create rows and columns

        Dim pSmallEnv As IEnvelope
        Dim left As Double
        Dim right As Double
        Dim top As Double
        Dim bottom As Double
        Dim gHgt As Double
        Dim gWth As Double

        left = pEnv.XMin
        right = pEnv.XMax
        top = pEnv.YMax
        bottom = pEnv.YMin

        gHgt = top - bottom
        gWth = right - left

        Dim rows As Integer
        Dim columns As Integer

        If Int(tbRows.Text) < 1 Then
            MsgBox("Number of rows must be at least 1")
            Exit Sub
        End If

        If Int(tbColumns.Text) < 1 Then
            MsgBox("Number of columns must be at least 1")
            Exit Sub
        End If

        rows = Int(tbRows.Text)
        columns = Int(tbColumns.Text)

        '    If rows = 0 Then
        '        MsgBox "Number of columns must be at least 1"
        '        Exit Sub
        '    End If
        '
        '    If columns < 1 Then
        '        MsgBox "Number of columns must be at least 1"
        '        Exit Sub
        '    End If

        Dim newTop As Double
        Dim newRight As Double
        Dim newBottom As Double
        Dim newLeft As Double
        Dim smallHgt As Double
        Dim smallWth As Double


        newTop = gHgt / rows + bottom
        newRight = gWth / columns + left
        newBottom = bottom
        newLeft = left


        'Dim pGraphicsCont As IGraphicsContainer
        pGraphicsCont = pMxDoc.ActiveView

        Dim pElement As IElement
        Dim rCount As Integer

        For cCount = 0 To columns - 1

            For rCount = 0 To rows - 1
                pSmallEnv = New Envelope
                pSmallEnv.PutCoords(newLeft, newBottom, newRight, newTop)
                smallHgt = pSmallEnv.YMax - pSmallEnv.YMin
                smallWth = pSmallEnv.XMax - pSmallEnv.XMin

                'pElement.Geometry = pSmallEnv
                pElement = createBox(pSmallEnv, mColor)

                newTop = newTop + smallHgt
                newBottom = newBottom + smallHgt

                'Dim pGraphicsCont As IGraphicsContainer
                'Set pGraphicsCont = pMxDoc.ActiveView
                pGraphicsCont.AddElement(pElement, 2)
                'pElement.Activate pMxDoc.ActiveView.ScreenDisplay
                'pMxDoc.ActiveView.Refresh

            Next rCount

            newTop = gHgt / rows + bottom
            newRight = newRight + smallWth
            newLeft = newLeft + smallWth
            newBottom = bottom
            rCount = 0

        Next cCount


        Dim pMap As IMap
        pMxDoc = My.ThisApplication.Document
        pMap = pMxDoc.FocusMap
        Dim pCompGLayer As ICompositeGraphicsLayer
        pCompGLayer = pMap.BasicGraphicsLayer
        Dim Bp As IBarrierProperties
        Bp = pCompGLayer
        Bp.Weight = 0

        pMxDoc.ActiveView.Refresh()
    End Sub



    Private Sub bClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bClearAll.Click

        Dim pMap As IMap
        pMxDoc = My.ThisApplication.Document
        pMap = pMxDoc.FocusMap
        pGrfxCont = pMap

        pGrfxCont.DeleteAllElements()

        pMxDoc.ActiveView.Refresh()
    End Sub


    Private Function createBox(ByVal pSmallEnv As IEnvelope, ByVal pColor As IColor) As IElement
        Dim pRectangleElement As IRectangleElement
        pRectangleElement = New RectangleElement

        Dim pNewElement As IElement
        pNewElement = pRectangleElement

        pNewElement.Geometry = pSmallEnv

        'pColor.RGB = RGB(0, 0, 0)
        pColor.Transparency = 0

        Dim pSimpleFS As ISimpleFillSymbol
        pSimpleFS = New SimpleFillSymbol
        pSimpleFS.Color = pColor
        pSimpleFS.Outline = New SimpleLineSymbol

        Dim pSimpleLS As ISimpleLineSymbol
        pSimpleLS = New SimpleLineSymbol
        'pColor.RGB = RGB(0, 0, 255)
        pColor.Transparency = 255
        pSimpleLS.Width = 1
        pSimpleLS.Color = pColor
        pSimpleFS.Outline = pSimpleLS

        Dim pFillSE As IFillShapeElement
        pFillSE = pNewElement
        pFillSE.Symbol = pSimpleFS

        createBox = pNewElement
    End Function

    Private Sub frmCreateBoxes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mColor = New RgbColor
        mColor.RGB = RGB(0, 0, 255)
        ColorDialog1.Color = Drawing.Color.DarkBlue
        txtColorSwatch.BackColor = ColorDialog1.Color
    End Sub

    Private Sub chkDisplayGfx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisplayGfx.CheckedChanged
        Dim pMap As IMap
        pMxDoc = My.ThisApplication.Document
        pMap = pMxDoc.FocusMap
        Dim pLayer As ILayer
        pLayer = pMap.BasicGraphicsLayer

        If Not chkDisplayGfx.Checked Then
            pLayer.Visible = False
        Else
            pLayer.Visible = True
        End If
        pMxDoc.ActiveView.Refresh()

    End Sub

    Private Sub bColorPkr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorPkr.Click
        ColorDialog1.ShowDialog()
        Dim rgbColor As RgbColor = New RgbColor
        rgbColor.Red = ColorDialog1.Color.R
        rgbColor.Green = ColorDialog1.Color.G
        rgbColor.Blue = ColorDialog1.Color.B
        mColor = rgbColor
        txtColorSwatch.BackColor = ColorDialog1.Color
    End Sub
End Class

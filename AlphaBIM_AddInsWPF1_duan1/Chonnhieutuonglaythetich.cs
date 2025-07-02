using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Threading.Tasks;
using Autodesk.Revit.UI.Selection;

namespace AlphaBIM
{
    public class Chonnhieutuonglaythetich : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            // Pick multiple walls
            IList<Reference> pickedRefs = null;
            try
            {
                pickedRefs = uidoc.Selection.PickObjects(ObjectType.Element, new WallSelectionFilter(), "Chọn nhiều tường để tính tổng thể tích");
            }
            catch
            {
                return Result.Cancelled;
            }

            double totalVolume = 0;
            foreach (Reference reference in pickedRefs)
            {
                Element wall = doc.GetElement(reference);
                Parameter volumeParam = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                if (volumeParam != null && volumeParam.StorageType == StorageType.Double)
                {
                    totalVolume += volumeParam.AsDouble();
                }
            }

            // Convert from Revit internal units (cubic feet) to cubic meters
            double totalVolume_m3 = UnitUtils.ConvertFromInternalUnits(totalVolume, UnitTypeId.CubicMeters);

            TaskDialog.Show("Tổng thể tích", $"Tổng thể tích các tường đã chọn: {totalVolume_m3:F2} m³");

            return Result.Succeeded;
        }

        private class WallSelectionFilter : ISelectionFilter
        {
            public bool AllowElement(Element elem)
            {
                return elem is Wall;
            }

            public bool AllowReference(Reference reference, XYZ position)
            {
                return true;
            }
        }
    }
}

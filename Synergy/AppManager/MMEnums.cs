using System;
using Mindjet.MindManager.Interop;

namespace SynManager
{
    internal class MMEnums
    {
        public static MmConnectionShape RelationshipShape(string value)
        {
            if (value == "mmConnectionShapeArrow")          return MmConnectionShape.mmConnectionShapeArrow;
            if (value == "mmConnectionShapeNoArrow")        return MmConnectionShape.mmConnectionShapeNoArrow;
            if (value == "mmConnectionShapeOpenArrow")      return MmConnectionShape.mmConnectionShapeOpenArrow;
            if (value == "mmConnectionShapeStealthArrow")   return MmConnectionShape.mmConnectionShapeStealthArrow;
            if (value == "mmConnectionShapeDiamondArrow")   return MmConnectionShape.mmConnectionShapeDiamondArrow;
            if (value == "mmConnectionShapeOvalArrow")      return MmConnectionShape.mmConnectionShapeOvalArrow;
            return MmConnectionShape.mmConnectionShapeArrow;
        }

        public static MmLineDashStyle LineDashStyle(string value)
        {
            if (value == "mmLineDashStyleDash")             return MmLineDashStyle.mmLineDashStyleDash;
            if (value == "mmLineDashStyleDashDot")          return MmLineDashStyle.mmLineDashStyleDashDot;
            if (value == "mmLineDashStyleLongDash")         return MmLineDashStyle.mmLineDashStyleLongDash;
            if (value == "mmLineDashStyleLongDashDot")      return MmLineDashStyle.mmLineDashStyleLongDashDot;
            if (value == "mmLineDashStyleLongDashDotDot")   return MmLineDashStyle.mmLineDashStyleLongDashDotDot;
            if (value == "mmLineDashStyleRoundDot")         return MmLineDashStyle.mmLineDashStyleRoundDot;
            if (value == "mmLineDashStyleSolid")            return MmLineDashStyle.mmLineDashStyleSolid;
            if (value == "mmLineDashStyleSquareDot")        return MmLineDashStyle.mmLineDashStyleSquareDot;
            return MmLineDashStyle.mmLineDashStyleSolid;
        }

        public static MmLineShape LineShape(string value)
        {
            if (value == "mmLineShapeBezier")       return MmLineShape.mmLineShapeBezier;
            if (value == "mmLineShapeAngled")       return MmLineShape.mmLineShapeAngled;
            if (value == "mmLineShapeCurved")       return MmLineShape.mmLineShapeCurved;
            if (value == "mmLineShapeRightAngle")   return MmLineShape.mmLineShapeRightAngle;
            if (value == "mmLineShapeStraight")     return MmLineShape.mmLineShapeStraight;
            return MmLineShape.mmLineShapeBezier;
        }

        public static MmBoundaryShape BoundaryShape(string value)
        {
            if (value == "mmBoundaryShapeCurvedLine")       return MmBoundaryShape.mmBoundaryShapeCurvedLine;
            if (value == "mmBoundaryShapeLines")            return MmBoundaryShape.mmBoundaryShapeLines;
            if (value == "mmBoundaryShapeZigzag")           return MmBoundaryShape.mmBoundaryShapeZigzag;
            if (value == "mmBoundaryShapeScallops")         return MmBoundaryShape.mmBoundaryShapeScallops;
            if (value == "mmBoundaryShapeWaves")            return MmBoundaryShape.mmBoundaryShapeWaves;
            if (value == "mmBoundaryShapeRectangle")        return MmBoundaryShape.mmBoundaryShapeRectangle;
            if (value == "mmBoundaryShapeCurvedRectangle")  return MmBoundaryShape.mmBoundaryShapeCurvedRectangle;
            if (value == "mmBoundaryShapeSummaryElbow")     return MmBoundaryShape.mmBoundaryShapeSummaryElbow;
            if (value == "mmBoundaryShapeSummaryShearedElbow") return MmBoundaryShape.mmBoundaryShapeSummaryShearedElbow;
            if (value == "mmBoundaryShapeSummaryArc")       return MmBoundaryShape.mmBoundaryShapeSummaryArc;
            if (value == "mmBoundaryShapeSummaryCurve")     return MmBoundaryShape.mmBoundaryShapeSummaryCurve;
            return MmBoundaryShape.mmBoundaryShapeCurvedRectangle;
        }

        public static string GetNumbering(Topic _t)
        {
            string numbering = SUtils.numberinguri;
            return
                _t.get_Attributes(numbering).GetAttributeValue("Depth") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Level1Text") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Level2Text") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Level3Text") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Level4Text") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Level5Text") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Numbering") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Separators") + ";" +
                _t.get_Attributes(numbering).GetAttributeValue("Repeat");
        }

        public static string GetFont(Topic t)
        {
            return
                t.TextColor.Value.ToString() + ";" +
                t.Font.Bold.ToString() + ";" +
                t.Font.Italic.ToString() + ";" +
                t.Font.Strikethrough.ToString() + ";" +
                t.Font.Underline.ToString() + ";" +
                t.Font.Size.ToString() + ";" +
                t.Font.Name.ToString();
        }

        public static MmTaskPriority Priority(string value)
        {
            if (value == "mmTaskPriority1") return MmTaskPriority.mmTaskPriority1;
            if (value == "mmTaskPriority2") return MmTaskPriority.mmTaskPriority2;
            if (value == "mmTaskPriority3") return MmTaskPriority.mmTaskPriority3;
            if (value == "mmTaskPriority4") return MmTaskPriority.mmTaskPriority4;
            if (value == "mmTaskPriority5") return MmTaskPriority.mmTaskPriority5;
            if (value == "mmTaskPriority6") return MmTaskPriority.mmTaskPriority6;
            if (value == "mmTaskPriority7") return MmTaskPriority.mmTaskPriority7;
            if (value == "mmTaskPriority8") return MmTaskPriority.mmTaskPriority8;
            if (value == "mmTaskPriority9") return MmTaskPriority.mmTaskPriority9;
            return MmTaskPriority.mmTaskPriorityNone;
        }

        public static MmDurationUnit DurationUnit(string value)
        {
            if (value == "mmDurationUnitHour") return MmDurationUnit.mmDurationUnitHour;
            if (value == "mmDurationUnitDay") return MmDurationUnit.mmDurationUnitDay;
            if (value == "mmDurationUnitWeek") return MmDurationUnit.mmDurationUnitWeek;
            if (value == "mmDurationUnitMonth") return MmDurationUnit.mmDurationUnitMonth;
            if (value == "mmDurationUnitMinute") return MmDurationUnit.mmDurationUnitMinute;
            return MmDurationUnit.mmDurationUnitDay; // default value = 0
        }

        public static MmStockIcon StockIcon(String value)
        {
            switch (value)
            {
                case "mmStockIconUnknown":          return MmStockIcon.mmStockIconUnknown;
                case "mmStockIconSmileyHappy":      return MmStockIcon.mmStockIconSmileyHappy;
                case "mmStockIconSmileyNeutral":    return MmStockIcon.mmStockIconSmileyNeutral;
                case "mmStockIconSmileySad":        return MmStockIcon.mmStockIconSmileySad;
                case "mmStockIconSmileyAngry":      return MmStockIcon.mmStockIconSmileyAngry;
                case "mmStockIconSmileyScreaming":  return MmStockIcon.mmStockIconSmileyScreaming;
                case "mmStockIconClock":            return MmStockIcon.mmStockIconClock;
                case "mmStockIconCalendar":         return MmStockIcon.mmStockIconCalendar;
                case "mmStockIconLetter":           return MmStockIcon.mmStockIconLetter;
                case "mmStockIconEmail":            return MmStockIcon.mmStockIconEmail;
                case "mmStockIconMailbox":          return MmStockIcon.mmStockIconMailbox;
                case "mmStockIconMegaphone":        return MmStockIcon.mmStockIconMegaphone;
                case "mmStockIconHouse":            return MmStockIcon.mmStockIconHouse;
                case "mmStockIconRolodex":          return MmStockIcon.mmStockIconRolodex;
                case "mmStockIconDollar":           return MmStockIcon.mmStockIconDollar;
                case "mmStockIconEuro":             return MmStockIcon.mmStockIconEuro;
                case "mmStockIconFlagRed":          return MmStockIcon.mmStockIconFlagRed;
                case "mmStockIconFlagBlue":         return MmStockIcon.mmStockIconFlagBlue;
                case "mmStockIconFlagGreen":        return MmStockIcon.mmStockIconFlagGreen;
                case "mmStockIconFlagBlack":        return MmStockIcon.mmStockIconFlagBlack;
                case "mmStockIconFlagOrange":       return MmStockIcon.mmStockIconFlagOrange;
                case "mmStockIconFlagYellow":       return MmStockIcon.mmStockIconFlagYellow;
                case "mmStockIconFlagPurple":       return MmStockIcon.mmStockIconFlagPurple;
                case "mmStockIconTrafficLightsRed": return MmStockIcon.mmStockIconTrafficLightsRed;
                case "mmStockIconMarker1":          return MmStockIcon.mmStockIconMarker1;
                case "mmStockIconMarker2":          return MmStockIcon.mmStockIconMarker2;
                case "mmStockIconMarker3":          return MmStockIcon.mmStockIconMarker3;
                case "mmStockIconMarker4":          return MmStockIcon.mmStockIconMarker4;
                case "mmStockIconMarker5":          return MmStockIcon.mmStockIconMarker5;
                case "mmStockIconMarker6":          return MmStockIcon.mmStockIconMarker6;
                case "mmStockIconMarker7":          return MmStockIcon.mmStockIconMarker7;
                case "mmStockIconResource1":        return MmStockIcon.mmStockIconResource1;
                case "mmStockIconResource2":        return MmStockIcon.mmStockIconResource2;
                case "mmStockIconPadlockLocked":    return MmStockIcon.mmStockIconPadlockLocked;
                case "mmStockIconPadlockUnlocked":  return MmStockIcon.mmStockIconPadlockUnlocked;
                case "mmStockIconArrowUp":          return MmStockIcon.mmStockIconArrowUp;
                case "mmStockIconArrowRight":       return MmStockIcon.mmStockIconArrowRight;
                case "mmStockIconTwoEndArrow":      return MmStockIcon.mmStockIconTwoEndArrow;
                case "mmStockIconPhone":            return MmStockIcon.mmStockIconPhone;
                case "mmStockIconCellphone":        return MmStockIcon.mmStockIconCellphone;
                case "mmStockIconCamera":           return MmStockIcon.mmStockIconCamera;
                case "mmStockIconFax":              return MmStockIcon.mmStockIconFax;
                case "mmStockIconStop":             return MmStockIcon.mmStockIconStop;
                case "mmStockIconExclamationMark":  return MmStockIcon.mmStockIconExclamationMark;
                case "mmStockIconQuestionMark":     return MmStockIcon.mmStockIconQuestionMark;
                case "mmStockIconThumbsUp":         return MmStockIcon.mmStockIconThumbsUp;
                case "mmStockIconOnHold":           return MmStockIcon.mmStockIconOnHold;
                case "mmStockIconHourglass":        return MmStockIcon.mmStockIconHourglass;
                case "mmStockIconEmergency":        return MmStockIcon.mmStockIconEmergency;
                case "mmStockIconNoEntry":          return MmStockIcon.mmStockIconNoEntry;
                case "mmStockIconBomb":             return MmStockIcon.mmStockIconBomb;
                case "mmStockIconKey":              return MmStockIcon.mmStockIconKey;
                case "mmStockIconGlasses":          return MmStockIcon.mmStockIconGlasses;
                case "mmStockIconJudgeHammer":      return MmStockIcon.mmStockIconJudgeHammer;
                case "mmStockIconRocket":           return MmStockIcon.mmStockIconRocket;
                case "mmStockIconScales":           return MmStockIcon.mmStockIconScales;
                case "mmStockIconRedo":             return MmStockIcon.mmStockIconRedo;
                case "mmStockIconLightbulb":        return MmStockIcon.mmStockIconLightbulb;
                case "mmStockIconCoffeeCup":        return MmStockIcon.mmStockIconCoffeeCup;
                case "mmStockIconTwoFeet":          return MmStockIcon.mmStockIconTwoFeet;
                case "mmStockIconMeeting":          return MmStockIcon.mmStockIconMeeting;
                case "mmStockIconCheck":            return MmStockIcon.mmStockIconCheck;
                case "mmStockIconNote":             return MmStockIcon.mmStockIconNote;
                case "mmStockIconThumbsDown":       return MmStockIcon.mmStockIconThumbsDown;
                case "mmStockIconArrowLeft":        return MmStockIcon.mmStockIconArrowLeft;
                case "mmStockIconArrowDown":        return MmStockIcon.mmStockIconArrowDown;
                case "mmStockIconBook":             return MmStockIcon.mmStockIconBook;
                case "mmStockIconMagnifyingGlass":  return MmStockIcon.mmStockIconMagnifyingGlass;
                case "mmStockIconBrokenConnection": return MmStockIcon.mmStockIconBrokenConnection;
                case "mmStockIconInformation":      return MmStockIcon.mmStockIconInformation;
                case "mmStockIconFolder":           return MmStockIcon.mmStockIconFolder;
                default: return 0;
            }
        }

        public static MmStandardTopicShape StandardTopicShape(String value)
        {
            switch (value)
            {
                case "mmStandardTopicShapeNone": return MmStandardTopicShape.mmStandardTopicShapeNone;
                case "mmStandardTopicShapeLine": return MmStandardTopicShape.mmStandardTopicShapeLine;
                case "mmStandardTopicShapeRectangle": return MmStandardTopicShape.mmStandardTopicShapeRectangle;
                case "mmStandardTopicShapeRoundedRectangle": return MmStandardTopicShape.mmStandardTopicShapeRoundedRectangle;
                case "mmStandardTopicShapeHexagon": return MmStandardTopicShape.mmStandardTopicShapeHexagon;
                case "mmStandardTopicShapeOctagon": return MmStandardTopicShape.mmStandardTopicShapeOctagon;
                case "mmStandardTopicShapeCircle": return MmStandardTopicShape.mmStandardTopicShapeCircle;
                case "mmStandardTopicShapeOval": return MmStandardTopicShape.mmStandardTopicShapeOval;
                case "mmStandardTopicShapeImage": return MmStandardTopicShape.mmStandardTopicShapeImage;
                case "mmStandardTopicShapeDiamond": return MmStandardTopicShape.mmStandardTopicShapeDiamond;
                case "mmStandardTopicShapeCapsule": return MmStandardTopicShape.mmStandardTopicShapeCapsule;
                case "mmStandardTopicShapeData": return MmStandardTopicShape.mmStandardTopicShapeData;
                case "mmStandardTopicShapeDatabase": return MmStandardTopicShape.mmStandardTopicShapeDatabase;
                case "mmStandardTopicShapePredefinedProcess": return MmStandardTopicShape.mmStandardTopicShapePredefinedProcess;
                case "mmStandardTopicShapeDocument": return MmStandardTopicShape.mmStandardTopicShapeDocument;
                default: return MmStandardTopicShape.mmStandardTopicShapeRoundedRectangle;
            }
        }

        public static MmFloatingTopicShape FloatingTopicShape(String value)
        {
            switch (value)
            {
                case "mmFloatingTopicShapeNone": return MmFloatingTopicShape.mmFloatingTopicShapeNone;
                case "mmFloatingTopicShapeRectangle": return MmFloatingTopicShape.mmFloatingTopicShapeRectangle;
                case "mmFloatingTopicShapeRoundedRectangle": return MmFloatingTopicShape.mmFloatingTopicShapeRoundedRectangle;
                case "mmFloatingTopicShapeOval": return MmFloatingTopicShape.mmFloatingTopicShapeOval;
                case "mmFloatingTopicShapeHighlight": return MmFloatingTopicShape.mmFloatingTopicShapeHighlight;
                case "mmFloatingTopicShapeImage": return MmFloatingTopicShape.mmFloatingTopicShapeImage;
                case "mmFloatingTopicShapeHexagon": return MmFloatingTopicShape.mmFloatingTopicShapeHexagon;
                case "mmFloatingTopicShapeOctagon": return MmFloatingTopicShape.mmFloatingTopicShapeOctagon;
                case "mmFloatingTopicShapeCircle": return MmFloatingTopicShape.mmFloatingTopicShapeCircle;
                case "mmFloatingTopicShapeLine": return MmFloatingTopicShape.mmFloatingTopicShapeLine;
                case "mmFloatingTopicShapeDiamond": return MmFloatingTopicShape.mmFloatingTopicShapeDiamond;
                case "mmFloatingTopicShapeCapsule": return MmFloatingTopicShape.mmFloatingTopicShapeCapsule;
                case "mmFloatingTopicShapeData": return MmFloatingTopicShape.mmFloatingTopicShapeData;
                case "mmFloatingTopicShapeDatabase": return MmFloatingTopicShape.mmFloatingTopicShapeDatabase;
                case "mmFloatingTopicShapePredefinedProcess": return MmFloatingTopicShape.mmFloatingTopicShapePredefinedProcess;
                case "mmFloatingTopicShapeDocument": return MmFloatingTopicShape.mmFloatingTopicShapeDocument;
                default: return MmFloatingTopicShape.mmFloatingTopicShapeRoundedRectangle;
            }
        }

        public static MmCalloutTopicShape CalloutTopicShape(String value)
        {
            switch (value)
            {
                case "mmCalloutTopicShapeNone": return MmCalloutTopicShape.mmCalloutTopicShapeNone;
                case "mmCalloutTopicShapeCalloutLine": return MmCalloutTopicShape.mmCalloutTopicShapeCalloutLine;
                case "mmCalloutTopicShapeRectangleBalloon": return MmCalloutTopicShape.mmCalloutTopicShapeRectangleBalloon;
                case "mmCalloutTopicShapeRoundedRectangleBalloon": return MmCalloutTopicShape.mmCalloutTopicShapeRoundedRectangleBalloon;
                case "mmCalloutTopicShapeOvalBalloon": return MmCalloutTopicShape.mmCalloutTopicShapeOvalBalloon;
                case "mmCalloutTopicShapeThoughtBubble": return MmCalloutTopicShape.mmCalloutTopicShapeThoughtBubble;
                case "mmCalloutTopicShapeHighlight": return MmCalloutTopicShape.mmCalloutTopicShapeHighlight;
                case "mmCalloutTopicShapeImage": return MmCalloutTopicShape.mmCalloutTopicShapeImage;
                case "mmCalloutTopicShapeRectangle": return MmCalloutTopicShape.mmCalloutTopicShapeRectangle;
                case "mmCalloutTopicShapeHexagon": return MmCalloutTopicShape.mmCalloutTopicShapeHexagon;
                case "mmCalloutTopicShapeOctagon": return MmCalloutTopicShape.mmCalloutTopicShapeOctagon;
                case "mmCalloutTopicShapeDiamond": return MmCalloutTopicShape.mmCalloutTopicShapeDiamond;
                case "mmCalloutTopicShapeCapsule": return MmCalloutTopicShape.mmCalloutTopicShapeCapsule;
                case "mmCalloutTopicShapeData": return MmCalloutTopicShape.mmCalloutTopicShapeData;
                case "mmCalloutTopicShapeDatabase": return MmCalloutTopicShape.mmCalloutTopicShapeDatabase;
                case "mmCalloutTopicShapePredefinedProcess": return MmCalloutTopicShape.mmCalloutTopicShapePredefinedProcess;
                case "mmCalloutTopicShapeDocument": return MmCalloutTopicShape.mmCalloutTopicShapeDocument;
                default: return MmCalloutTopicShape.mmCalloutTopicShapeRoundedRectangleBalloon;
            }
        }
    }
}

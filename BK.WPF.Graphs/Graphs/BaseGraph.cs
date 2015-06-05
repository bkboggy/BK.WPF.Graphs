using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BK.WPF.Graphs.Graphs
{
    public class BaseGraph : Control
    {
        #region Colors

        private const string NORMAL_STATE_COLOR = "#FF3CC9FF";
        private const string MOUSE_OVER_STATE_COLOR = "#FF89DCFC";
        private const string MOUSE_DOWN_STATE_COLOR = "#FFCEF1FF";
        private const string DEFAULT_DARK_TEXT_COLOR = "Black";
        private const string DEFAULT_MEDIUM_TEXT_COLOR = "#FF5C5C5C";
        private const string DEFAULT_LIGHT_TEXT_COLOR = "#FF8A8A8A";

        #endregion

        #region Dependency Properties

        #region Title

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title",
            typeof (string), typeof (BaseGraph));

        public static readonly DependencyProperty TitleFontColorProperty = DependencyProperty.Register("TitleFontColor",
            typeof (Brush), typeof (BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_DARK_TEXT_COLOR)));

        public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register("TitleFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(16.0));

        public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register("TitleFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty TitleFontStyleProperty = DependencyProperty.Register("TitleFontStyle",
            typeof (FontStyle), typeof (BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty TitleFontWeightProperty = DependencyProperty.Register("TitleFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Medium));

        public static readonly DependencyProperty TitlePositionProperty = DependencyProperty.Register("TitlePosition",
            typeof (HorizontalAlignment), typeof (BaseGraph), new PropertyMetadata(HorizontalAlignment.Center));

        public static readonly DependencyProperty TitleMarginProperty = DependencyProperty.Register("TitleMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ShowTitleProperty = DependencyProperty.Register("ShowTitle",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region Subtitle

        public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register("Subtitle",
            typeof (string), typeof (BaseGraph));

        public static readonly DependencyProperty SubtitleFontColorProperty = DependencyProperty.Register("SubtitleFontColor",
            typeof (Brush), typeof (BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_LIGHT_TEXT_COLOR)));

        public static readonly DependencyProperty SubtitleFontSizeProperty = DependencyProperty.Register("SubtitleFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(12.0));

        public static readonly DependencyProperty SubtitleFontFamilyProperty = DependencyProperty.Register("SubtitleFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty SubtitleFontStyleProperty = DependencyProperty.Register("SubtitleFontStyle",
            typeof (FontStyle), typeof (BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty SubtitleFontWeightProperty = DependencyProperty.Register("SubtitleFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty SubtitlePositionProperty = DependencyProperty.Register("SubtitlePosition",
            typeof (HorizontalAlignment), typeof (BaseGraph), new PropertyMetadata(HorizontalAlignment.Center));

        public static readonly DependencyProperty SubtitleMarginProperty = DependencyProperty.Register("SubtitleMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ShowSubtitleProperty = DependencyProperty.Register("ShowSubtitle",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region ValueAxisLabel

        public static readonly DependencyProperty ValueAxisLabelProperty = DependencyProperty.Register("ValueAxisLabel",
            typeof(string), typeof(BaseGraph));

        public static readonly DependencyProperty ValueAxisLabelFontColorProperty = DependencyProperty.Register("ValueAxisLabelFontColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_MEDIUM_TEXT_COLOR)));

        public static readonly DependencyProperty ValueAxisLabelFontSizeProperty = DependencyProperty.Register("ValueAxisLabelFontSize",
            typeof(double), typeof(BaseGraph), new PropertyMetadata(14.0));

        public static readonly DependencyProperty ValueAxisLabelFontFamilyProperty = DependencyProperty.Register("ValueAxisLabelFontFamily",
            typeof(FontFamily), typeof(BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty ValueAxisLabelFontStyleProperty = DependencyProperty.Register("ValueAxisLabelFontStyle",
            typeof(FontStyle), typeof(BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty ValueAxisLabelFontWeightProperty = DependencyProperty.Register("ValueAxisLabelFontWeight",
            typeof(FontWeight), typeof(BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty ValueAxisLabelMarginProperty = DependencyProperty.Register("ValueAxisLabelMargin",
            typeof(Thickness), typeof(BaseGraph));

        public static readonly DependencyProperty ShowValueAxisLabelsProperty = DependencyProperty.Register("ShowValueAxisLabels",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region CategoryAxisLabel

        public static readonly DependencyProperty CategoryAxisLabelProperty = DependencyProperty.Register("CategoryAxisLabel",
            typeof (string), typeof (BaseGraph));

        public static readonly DependencyProperty CategoryAxisLabelFontColorProperty = DependencyProperty.Register("CategoryAxisLabelFontColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_MEDIUM_TEXT_COLOR)));

        public static readonly DependencyProperty CategoryAxisLabelFontSizeProperty = DependencyProperty.Register("CategoryAxisLabelFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(14.0));

        public static readonly DependencyProperty CategoryAxisLabelFontFamilyProperty = DependencyProperty.Register("CategoryAxisLabelFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty CategoryAxisLabelFontStyleProperty = DependencyProperty.Register("CategoryAxisLabelFontStyle",
            typeof (FontStyle), typeof (BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty CategoryAxisLabelFontWeightProperty = DependencyProperty.Register("CategoryAxisLabelFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty CategoryAxisLabelMarginProperty = DependencyProperty.Register("CategoryAxisLabelMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ShowCategoryAxisLabelsProperty = DependencyProperty.Register("ShowCategoryAxisLabels",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region ValueAxisText

        public static readonly DependencyProperty ValueAxisFontColorProperty = DependencyProperty.Register("ValueAxisFontColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_LIGHT_TEXT_COLOR)));

        public static readonly DependencyProperty ValueAxisFontSizeProperty = DependencyProperty.Register("ValueAxisFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(9.0));

        public static readonly DependencyProperty ValueAxisFontFamilyProperty = DependencyProperty.Register("ValueAxisFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty ValueAxisFontStyleProperty = DependencyProperty.Register("ValueAxisFontStyle",
            typeof (FontStyle), typeof (BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty ValueAxisFontWeightProperty = DependencyProperty.Register("ValueAxisFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty ValueAxisMarginProperty = DependencyProperty.Register("ValueAxisMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ShowValueAxisTextProperty = DependencyProperty.Register("ShowValueAxisText",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region CategoryAxisText

        public static readonly DependencyProperty CategoryAxisFontColorProperty = DependencyProperty.Register("CategoryAxisFontColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_LIGHT_TEXT_COLOR)));

        public static readonly DependencyProperty CategoryAxisFontSizeProperty = DependencyProperty.Register("CategoryAxisFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(9.0));

        public static readonly DependencyProperty CategoryAxisFontFamilyProperty = DependencyProperty.Register("CategoryAxisFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty CategoryAxisFontStyleProperty = DependencyProperty.Register("CategoryAxisFontStyle",
            typeof (FontStyle), typeof (BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty CategoryAxisFontWeightProperty = DependencyProperty.Register("CategoryAxisFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty CategoryMarginProperty = DependencyProperty.Register("CategoryAxisMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ShowCategoryAxisTextProperty = DependencyProperty.Register("ShowCategoryAxisText",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region ItemLabel

        public static readonly DependencyProperty ItemLabelFontColorProperty = DependencyProperty.Register("ItemLabelFontColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_LIGHT_TEXT_COLOR)));

        public static readonly DependencyProperty ItemLabelFontSizeProperty = DependencyProperty.Register("ItemLabelFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(9.0));

        public static readonly DependencyProperty ItemLabelFontFamilyProperty = DependencyProperty.Register("ItemLabelFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty ItemLabelFontStyleProperty = DependencyProperty.Register("ItemLabelFontStyle",
            typeof (FontStyle), typeof (BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty ItemLabelFontWeightProperty = DependencyProperty.Register("ItemLabelFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty ItemLabelMarginProperty = DependencyProperty.Register("ItemLabelMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ShowItemLabelsProperty = DependencyProperty.Register("ShowItemLabels",
            typeof (bool), typeof (BaseGraph), new PropertyMetadata(true));

        #endregion

        #region ItemText

        public static readonly DependencyProperty ItemTextFontColorProperty = DependencyProperty.Register("ItemTextFontColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(DEFAULT_MEDIUM_TEXT_COLOR)));

        public static readonly DependencyProperty ItemTextFontSizeProperty = DependencyProperty.Register("ItemTextFontSize",
            typeof (double), typeof (BaseGraph), new PropertyMetadata(9.0));

        public static readonly DependencyProperty ItemTextFontFamilyProperty = DependencyProperty.Register("ItemTextFontFamily",
            typeof (FontFamily), typeof (BaseGraph), new PropertyMetadata(new FontFamily("Segoe UI, Verdana")));

        public static readonly DependencyProperty ItemTextFontStyleProperty = DependencyProperty.Register("ItemTextFontStyle",
            typeof (FontStyle), typeof(BaseGraph), new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty ItemTextFontWeightProperty = DependencyProperty.Register("ItemTextFontWeight",
            typeof (FontWeight), typeof (BaseGraph), new PropertyMetadata(FontWeights.Normal));

        public static readonly DependencyProperty ItemTextMarginProperty = DependencyProperty.Register("ItemTextMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ItemTextPositionProperty = DependencyProperty.Register("ItemTexPosition",
            typeof (int), typeof (BaseGraph), new PropertyMetadata(0));

        public static readonly DependencyProperty ShowItemTextProperty = DependencyProperty.Register("ShowText",
            typeof(bool), typeof(BaseGraph), new PropertyMetadata(true));

        #endregion

        #region ItemsPanel

        public static readonly DependencyProperty ItemsPanelBackgroundProperty = DependencyProperty.Register("ItemsPanelBackground",
            typeof(Brush), typeof(BaseGraph));

        public static readonly DependencyProperty ItemsPanelMarginProperty = DependencyProperty.Register("ItemsPanelMargin",
            typeof (Thickness), typeof (BaseGraph));

        public static readonly DependencyProperty ItemsPanelPaddingProperty = DependencyProperty.Register("ItemsPanelPadding",
            typeof(Thickness), typeof(BaseGraph));

        #endregion

        #region Item

        public static readonly DependencyProperty ItemColorProperty = DependencyProperty.Register("ItemColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(NORMAL_STATE_COLOR)));

        public static readonly DependencyProperty ItemMouseOverColorProperty = DependencyProperty.Register("ItemMouseOverColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(MOUSE_OVER_STATE_COLOR)));

        public static readonly DependencyProperty ItemMouseDownColorProperty = DependencyProperty.Register("ItemMouseDownColor",
            typeof(Brush), typeof(BaseGraph), new PropertyMetadata(new BrushConverter().ConvertFrom(MOUSE_DOWN_STATE_COLOR)));

        public static readonly DependencyProperty ItemSpacingProperty = DependencyProperty.Register("ItemSpacing",
            typeof(Thickness), typeof(BaseGraph), new PropertyMetadata(new Thickness(10, 0, 10, 0)));

        #endregion

        #region Items

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items",
            typeof(IEnumerable<object>), typeof(BaseGraph));

        #endregion

        #region Data

        public static readonly DependencyProperty ValuePropertyNameProperty = DependencyProperty.Register("ValuePropertyName",
            typeof(string), typeof(BaseGraph), new PropertyMetadata("Value"));

        #endregion

        #endregion

        #region CLR Properties

        #region Title

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Brush TitleFontColor
        {
            get { return (Brush) GetValue(TitleFontColorProperty); }
            set { SetValue(TitleFontColorProperty, value); }
        }

        public FontFamily TitleFontFamily
        {
            get { return (FontFamily) GetValue(TitleFontFamilyProperty); }
            set { SetValue(TitleFontFamilyProperty, value); }
        }

        public FontStyle TitleFontStyle
        {
            get { return (FontStyle) GetValue(TitleFontStyleProperty); }
            set { SetValue(TitleFontStyleProperty, value); }
        }

        public FontWeight TitleFontWeight
        {
            get { return (FontWeight) GetValue(TitleFontWeightProperty); }
            set { SetValue(TitleFontWeightProperty, value); }
        }

        public double TitleFontSize
        {
            get { return (double) GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        public HorizontalAlignment TitlePosition
        {
            get { return (HorizontalAlignment) GetValue(TitlePositionProperty); }
            set { SetValue(TitlePositionProperty, value); }
        }

        public Thickness TitleMargin
        {
            get { return (Thickness) GetValue(TitleMarginProperty); }
            set { SetValue(TitleMarginProperty, value); }
        }

        public bool ShowTitle
        {
            get { return (bool) GetValue(ShowTitleProperty); }
            set { SetValue(ShowTitleProperty, value); }
        }

        #endregion

        #region Subtitle

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set { SetValue(SubtitleProperty, value); }
        }

        public Brush SubtitleFontColor
        {
            get { return (Brush)GetValue(SubtitleFontColorProperty); }
            set { SetValue(SubtitleFontColorProperty, value); }
        }

        public FontFamily SubtitleFontFamily
        {
            get { return (FontFamily)GetValue(SubtitleFontFamilyProperty); }
            set { SetValue(SubtitleFontFamilyProperty, value); }
        }

        public FontStyle SubtitleFontStyle
        {
            get { return (FontStyle)GetValue(SubtitleFontStyleProperty); }
            set { SetValue(SubtitleFontStyleProperty, value); }
        }

        public FontWeight SubtitleFontWeight
        {
            get { return (FontWeight)GetValue(SubtitleFontWeightProperty); }
            set { SetValue(SubtitleFontWeightProperty, value); }
        }

        public double SubtitleFontSize
        {
            get { return (double)GetValue(SubtitleFontSizeProperty); }
            set { SetValue(SubtitleFontSizeProperty, value); }
        }

        public HorizontalAlignment SubtitlePosition
        {
            get { return (HorizontalAlignment)GetValue(SubtitlePositionProperty); }
            set { SetValue(SubtitlePositionProperty, value); }
        }

        public Thickness SubtitleMargin
        {
            get { return (Thickness)GetValue(SubtitleMarginProperty); }
            set { SetValue(SubtitleMarginProperty, value); }
        }

        public bool ShowSubtitle
        {
            get { return (bool)GetValue(ShowSubtitleProperty); }
            set { SetValue(ShowSubtitleProperty, value); }
        }

        #endregion

        #region ValueAxisLabel

        public string ValueAxisLabel
        {
            get { return (string) GetValue(ValueAxisLabelProperty); }
            set { SetValue(ValueAxisLabelProperty, value); }
        }

        public Brush ValueAxisLabelFontColor
        {
            get { return (Brush) GetValue(ValueAxisLabelFontColorProperty); }
            set { SetValue(ValueAxisLabelFontColorProperty, value); }
        }

        public double ValueAxisLabelFontSize
        {
            get { return (double) GetValue(ValueAxisLabelFontSizeProperty); }
            set { SetValue(ValueAxisLabelFontSizeProperty, value); }
        }

        public FontFamily ValueAxisLabelFontFamily
        {
            get { return (FontFamily) GetValue(ValueAxisLabelFontFamilyProperty); }
            set { SetValue(ValueAxisLabelFontFamilyProperty, value); }
        }

        public FontStyle ValueAxisLabelFontStyle
        {
            get { return (FontStyle) GetValue(ValueAxisLabelFontStyleProperty); }
            set { SetValue(ValueAxisLabelFontStyleProperty, value); }
        }

        public FontWeight ValueAxisLabelFontWeight
        {
            get { return (FontWeight) GetValue(ValueAxisLabelFontWeightProperty); }
            set { SetValue(ValueAxisLabelFontWeightProperty, value); }
        }

        public Thickness ValueAxisLabelMargin
        {
            get { return (Thickness) GetValue(ValueAxisLabelMarginProperty); }
            set { SetValue(ValueAxisLabelMarginProperty, value); }
        }

        public bool ShowValueAxisLabels
        {
            get { return (bool) GetValue(ShowValueAxisLabelsProperty); }
            set { SetValue(ShowValueAxisLabelsProperty, value); }
        }

        #endregion

        #region CategoryAxisLabel

        public string CategoryAxisLabel
        {
            get { return (string)GetValue(CategoryAxisLabelProperty); }
            set { SetValue(CategoryAxisLabelProperty, value); }
        }

        public Brush CategoryAxisLabelFontColor
        {
            get { return (Brush)GetValue(CategoryAxisLabelFontColorProperty); }
            set { SetValue(CategoryAxisLabelFontColorProperty, value); }
        }

        public double CategoryAxisLabelFontSize
        {
            get { return (double)GetValue(CategoryAxisLabelFontSizeProperty); }
            set { SetValue(CategoryAxisLabelFontSizeProperty, value); }
        }

        public FontFamily CategoryAxisLabelFontFamily
        {
            get { return (FontFamily)GetValue(CategoryAxisLabelFontFamilyProperty); }
            set { SetValue(CategoryAxisLabelFontFamilyProperty, value); }
        }

        public FontStyle CategoryAxisLabelFontStyle
        {
            get { return (FontStyle)GetValue(CategoryAxisLabelFontStyleProperty); }
            set { SetValue(CategoryAxisLabelFontStyleProperty, value); }
        }

        public FontWeight CategoryAxisLabelFontWeight
        {
            get { return (FontWeight)GetValue(CategoryAxisLabelFontWeightProperty); }
            set { SetValue(CategoryAxisLabelFontWeightProperty, value); }
        }

        public Thickness CategoryAxisLabelMargin
        {
            get { return (Thickness)GetValue(CategoryAxisLabelMarginProperty); }
            set { SetValue(CategoryAxisLabelMarginProperty, value); }
        }

        public bool ShowCategoryAxisLabels
        {
            get { return (bool)GetValue(ShowCategoryAxisLabelsProperty); }
            set { SetValue(ShowCategoryAxisLabelsProperty, value); }
        }

        #endregion

        #region ValueAxisText

        public Brush ValueAxisFontColor
        {
            get { return (Brush)GetValue(ValueAxisFontColorProperty); }
            set { SetValue(ValueAxisFontColorProperty, value); }
        }

        public double ValueAxisFontSize
        {
            get { return (double)GetValue(ValueAxisFontSizeProperty); }
            set { SetValue(ValueAxisFontSizeProperty, value); }
        }

        public FontFamily ValueAxisFontFamily
        {
            get { return (FontFamily)GetValue(ValueAxisFontFamilyProperty); }
            set { SetValue(ValueAxisFontFamilyProperty, value); }
        }

        public FontStyle ValueAxisFontStyle
        {
            get { return (FontStyle)GetValue(ValueAxisFontStyleProperty); }
            set { SetValue(ValueAxisFontStyleProperty, value); }
        }

        public FontWeight ValueAxisFontWeight
        {
            get { return (FontWeight)GetValue(ValueAxisFontWeightProperty); }
            set { SetValue(ValueAxisFontWeightProperty, value); }
        }

        public bool ShowValueAxisText
        {
            get { return (bool)GetValue(ShowValueAxisLabelsProperty); }
            set { SetValue(ShowValueAxisLabelsProperty, value); }
        }

        #endregion

        #region CategoryAxisText

        public Brush CategoryAxisFontColor
        {
            get { return (Brush)GetValue(CategoryAxisFontColorProperty); }
            set { SetValue(CategoryAxisFontColorProperty, value); }
        }

        public double CategoryAxisFontSize
        {
            get { return (double)GetValue(CategoryAxisFontSizeProperty); }
            set { SetValue(CategoryAxisFontSizeProperty, value); }
        }

        public FontFamily CategoryAxisFontFamily
        {
            get { return (FontFamily)GetValue(CategoryAxisFontFamilyProperty); }
            set { SetValue(CategoryAxisFontFamilyProperty, value); }
        }

        public FontStyle CategoryAxisFontStyle
        {
            get { return (FontStyle)GetValue(CategoryAxisFontStyleProperty); }
            set { SetValue(CategoryAxisFontStyleProperty, value); }
        }

        public FontWeight CategoryAxisFontWeight
        {
            get { return (FontWeight)GetValue(CategoryAxisFontWeightProperty); }
            set { SetValue(CategoryAxisFontWeightProperty, value); }
        }

        public bool ShowCategoryAxisText
        {
            get { return (bool)GetValue(ShowCategoryAxisLabelsProperty); }
            set { SetValue(ShowCategoryAxisLabelsProperty, value); }
        }

        #endregion

        #region ItemLabel

        public Brush ItemLabelFontColor
        {
            get { return (Brush)GetValue(ItemLabelFontColorProperty); }
            set { SetValue(ItemLabelFontColorProperty, value); }
        }

        public double ItemLabelFontSize
        {
            get { return (double)GetValue(ItemLabelFontSizeProperty); }
            set { SetValue(ItemLabelFontSizeProperty, value); }
        }

        public FontFamily ItemLabelFontFamily
        {
            get { return (FontFamily)GetValue(ItemLabelFontFamilyProperty); }
            set { SetValue(ItemLabelFontFamilyProperty, value); }
        }

        public FontStyle ItemLabelFontStyle
        {
            get { return (FontStyle)GetValue(ItemLabelFontStyleProperty); }
            set { SetValue(ItemLabelFontStyleProperty, value); }
        }

        public FontWeight ItemLabelFontWeight
        {
            get { return (FontWeight)GetValue(ItemLabelFontWeightProperty); }
            set { SetValue(ItemLabelFontWeightProperty, value); }
        }

        public Thickness ItemLabelMargin
        {
            get { return (Thickness) GetValue(ItemLabelMarginProperty); }
            set { SetValue(ItemLabelMarginProperty, value); }
        }

        public bool ShowItemLabels
        {
            get { return (bool)GetValue(ShowItemLabelsProperty); }
            set { SetValue(ShowItemLabelsProperty, value); }
        }

        #endregion

        #region ItemText

        public Brush ItemTextFontColor
        {
            get { return (Brush)GetValue(ItemTextFontColorProperty); }
            set { SetValue(ItemTextFontColorProperty, value); }
        }

        public double ItemTextFontSize
        {
            get { return (double)GetValue(ItemTextFontSizeProperty); }
            set { SetValue(ItemTextFontSizeProperty, value); }
        }

        public FontFamily ItemTextFontFamily
        {
            get { return (FontFamily)GetValue(ItemTextFontFamilyProperty); }
            set { SetValue(ItemTextFontFamilyProperty, value); }
        }

        public FontStyle ItemTextFontStyle
        {
            get { return (FontStyle)GetValue(ItemTextFontStyleProperty); }
            set { SetValue(ItemTextFontStyleProperty, value); }
        }

        public FontWeight ItemTextFontWeight
        {
            get { return (FontWeight)GetValue(ItemTextFontWeightProperty); }
            set { SetValue(ItemTextFontWeightProperty, value); }
        }

        public Thickness ItemTextMargin
        {
            get { return (Thickness)GetValue(ItemTextMarginProperty); }
            set { SetValue(ItemTextMarginProperty, value); }
        }

        public int ItemTextPosition
        {
            get { return (int) GetValue(ItemTextPositionProperty); }
            set { SetValue(ItemTextPositionProperty, value); }
        }

        public bool ShowItemText
        {
            get { return (bool)GetValue(ShowItemTextProperty); }
            set { SetValue(ShowItemTextProperty, value); }
        }

        #endregion

        #region ItemsPanel

        public Brush ItemsPanelBackground
        {
            get { return (Brush) GetValue(ItemsPanelBackgroundProperty); }
            set { SetValue(ItemsPanelBackgroundProperty, value); }
        }

        public Thickness ItemsPanelMargin
        {
            get { return (Thickness) GetValue(ItemsPanelMarginProperty); }
            set { SetValue(ItemsPanelMarginProperty, value); }
        }

        public Thickness ItemsPanelPadding
        {
            get { return (Thickness) GetValue(ItemsPanelPaddingProperty); }
            set { SetValue(ItemsPanelPaddingProperty, value); }
        }

        #endregion

        #region Item

        public Brush ItemColor
        {
            get { return (Brush) GetValue(ItemColorProperty); }
            set { SetValue(ItemColorProperty, value); }
        }

        public Brush ItemMouseOverColor
        {
            get { return (Brush) GetValue(ItemMouseOverColorProperty); }
            set { SetValue(ItemMouseOverColorProperty, value); }
        }

        public Brush ItemMouseDownColor
        {
            get { return (Brush) GetValue(ItemMouseDownColorProperty); }
            set { SetValue(ItemMouseDownColorProperty, value); }
        }

        public Thickness ItemSpacing
        {
            get { return (Thickness) GetValue(ItemSpacingProperty); }
            set { SetValue(ItemSpacingProperty, value); }
        }

        #endregion

        #region Items

        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>) GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #endregion

        #region Data

        public string ValuePropertyName
        {
            get { return (string) GetValue(ValuePropertyNameProperty); }
            set { SetValue(ValuePropertyNameProperty, this); }
        }

        #endregion

        #endregion

        static BaseGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseGraph),
                new FrameworkPropertyMetadata(typeof(BaseGraph)));
        }
    }
}

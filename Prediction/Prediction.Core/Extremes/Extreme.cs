using Prediction.DataProvider.Dto;

namespace Prediction.Core.Curve.Extremes;

public class Extreme
{
    public int Time { get; set; }
    public float Value { get; set; }
    public int ExtremeGroup { get; set; }
    public bool MergeExtreme { get; set; }

}

public static class ExtremeExtensions
{
    public static ExtremeDto ToDto(this Extreme extreme)
    {
        return new ExtremeDto
        {
            Value = extreme.Value,
            ExtremeGroup = extreme.ExtremeGroup,
            MergeExtreme = extreme.MergeExtreme,
            Time = extreme.Time,
        };
    }
    public static Extreme ToExterme(this ExtremeDto dto)
    {
        return new Extreme
        {
            Value = dto.Value,
            ExtremeGroup = dto.ExtremeGroup,
            MergeExtreme = dto.MergeExtreme,
            Time = dto.Time,
        };
    }
}
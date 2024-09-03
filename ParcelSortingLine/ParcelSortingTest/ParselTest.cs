using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParcelSortingline;
using Program = ParcelSortingline.Program;

namespace ParcelSortingTest
{
    public class ParcelTest
    {
        [Fact]
        public void When_ParcelAndSortingLineHasNewDimensions_Then_ParcelCannotFitSortingLine()
        {
            var boxSizes = new List<BoxSize>()
            {
                new BoxSize
                {
                    Length = 70,
                    Width = 50,
                    SortingLineParams = new List<SortingLineParam>()
                    {
                        new SortingLineParam
                        {
                            LineWidth = 50,
                        },
                        new SortingLineParam
                        {
                            LineWidth = 50,
                        },
                        new SortingLineParam
                        {
                            LineWidth = 100,
                        },
                        new SortingLineParam
                        {
                            LineWidth = 100,
                        },
                    }
                }
            };

            bool result = Program.ParcelLineFitController(boxSizes);
            Assert.False(result);
        }
    }
}
namespace ParcelSortingline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ParcelLineFitController(BoxSizes);
        }

        public static bool ParcelLineFitController(List<BoxSize> boxSizes)
        {
            bool parcelFits = false;

            foreach (BoxSize boxSize in boxSizes)
            {
                Console.WriteLine("\n");
                Console.WriteLine("New sorting line starts here: ");

                var boxLengthInHalf = boxSize.Length / 2;
                var halfParcelDiagonal = Math.Sqrt((boxLengthInHalf * boxLengthInHalf) + (boxSize.Width * boxSize.Width));
                var lineWidth = 0;

                foreach (SortingLineParam sortingLine in boxSize.SortingLineParams)
                {

                    var cornerDiagonal = Math.Sqrt((sortingLine.LineWidth * sortingLine.LineWidth)
                        + (lineWidth * lineWidth));


                    if (sortingLine.LineWidth >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits",
                            sortingLine.LineWidth);
                    }
                    else if (boxSize.Width >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits",
                            sortingLine.LineWidth);
                    }
                    else if (boxSize.Width >= sortingLine.LineWidth ||
                             boxSize.Length <= sortingLine.LineWidth)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits",
                            sortingLine.LineWidth);
                    }
                    else if (boxSize.Width >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits",
                            sortingLine.LineWidth);
                    }
                    else if (sortingLine.LineWidth <= halfParcelDiagonal &&
                        lineWidth >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits",
                            sortingLine.LineWidth);
                    }

                    else if (sortingLine.LineWidth <= halfParcelDiagonal &&
                        sortingLine.LineWidth >= cornerDiagonal)
                    {
                        parcelFits = sortingLine.LineWidth <= halfParcelDiagonal &&
                            sortingLine.LineWidth >= cornerDiagonal;

                        var result = parcelFits
                            ? "Sorting line width is " + sortingLine.LineWidth + " and it fits" :
                            "It doesnt fit to the sorting line and needs to be wider";
                        Console.WriteLine(result);
                    }

                    else
                    {
                        Console.WriteLine("It doesnt fit to the sorting line and it needs to be wider");
                    }

                    lineWidth = sortingLine.LineWidth;
                }
            }


            return parcelFits;
        }


        public static readonly List<BoxSize> BoxSizes = new List<BoxSize>
        {
            new BoxSize
            {
                Length = 120,
                Width = 60,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 100
                    },
                    new SortingLineParam
                    {
                        LineWidth = 75
                    }
                }
            },

            new BoxSize
            {
                Length = 100,
                Width = 35,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 75
                    },
                    new SortingLineParam
                    {
                        LineWidth = 50
                    },
                    new SortingLineParam
                    {
                        LineWidth = 80
                    },
                    new SortingLineParam
                    {
                        LineWidth = 100
                    },
                    new SortingLineParam
                    {
                        LineWidth = 37
                    },
                }
            },

            new BoxSize
            {
                Length = 70,
                Width = 50,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 60
                    },
                    new SortingLineParam
                    {
                        LineWidth= 60
                    },
                    new SortingLineParam
                    {
                        LineWidth = 55
                    },
                    new SortingLineParam
                    {
                        LineWidth= 90
                    }
                }
            }
        };
    }

    public class BoxSize
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public List<SortingLineParam> SortingLineParams { get; set; }
            = new List<SortingLineParam>();
    }

    public class SortingLineParam
    {
        public int LineWidth { get; set; }
    }
}
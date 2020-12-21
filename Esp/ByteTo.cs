using System;

namespace Esp
{
    public enum ByteTo:long
    {
        BYTE = 1,
        KB = 1024, // 0x0000000000000400
        MB = 1048576, // 0x0000000000100000
        GB = 1073741824, // 0x0000000040000000
        TB = 1099511627776, // 0x0000010000000000
        EB = 1152921504606847000, // 0x1000000000000018
    }

    public static class Convert
    {
        public static long FromStringToByteGetLong(string value)
        {
            switch (value)
            {
                case "BYTE":
                    return 1;
                case "KB":
                    return 1024;
                case "MB":
                    return 1048576;
                case "GB":
                    return 1073741824;
                case "TB":
                    return 1099511627776;
                case "EB":
                    return 1152921504606847000;
                default:
                    throw new Exception("Wrong string format to convert!");
            }
        }
    }
}
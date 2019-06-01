using System.Runtime.InteropServices;

namespace LZ4
{
    public static unsafe class LZ4
    {
        private const string NativeLibraryName = "lz4";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_versionNumber();

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern byte* LZ4_versionString();

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_compress_default(byte* src, byte* dst, int srcSize, int dstCapacity);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_decompress_safe(byte* src, byte* dst, int compressedSize, int dstCapacity);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_compressBound(int inputSize);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_compress_fast(byte* src, byte* dst, int srcSize, int dstCapacity, int acceleration);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_sizeofState();

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_compress_fast_extState(byte* state, byte* src, byte* dst, int srcSize, int dstCapacity, int acceleration);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_compress_destSize(byte* src, byte* dst, ref int srcSizePtr, int targetDstSize);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_decompress_fast(byte* src, byte* dst, int originalSize);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_decompress_safe_partial(byte* src, byte* dst, int srcSize, int targetOutputSize, int dstCapacity);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_decoderRingBufferSize(int maxBlockSize);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_decompress_safe_usingDict(byte* src, byte* dst, int srcSize, int dstCapacity, byte* dictStart, int dictSize);

        [DllImport(NativeLibraryName, CallingConvention = NativeCallingConvention)]
        public static extern int LZ4_decompress_fast_usingDict(byte* src, byte* dst, int originalSize, byte* dictStart, int dictSize);
    }
}

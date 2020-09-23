#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("RaGnVrb4BZu9miauWxk7jznCaLNV52RHVWhjbE/jLeOSaGRkZGBlZu/uquNvfoQGkyOe1SN2VpbDg+T/u+xzvKYu1ocFT5krY0Ppj0+EFj3HO/pvnSKqMuhByu2gWfjXWtUP9+py7ypwAUgX3xepPciu0Lf7raQQ1YBQrASr1R5KamKx+KhqL1f+x/EiuDqbK7znHztepNLJZduRsEc7utGQblzQVMeb4qIn/MsbBXCaQSnkwVX8YbLu/uoJSO++xDs1QxTlZ4sRLrEHB3d7eNalUp7IZ3he21WPwtZWX5TR8DS8mpdt6MHol/yMik2m52RqZVXnZG9n52RkZddDVf1bLRfNw2QPvKhmYyqbBHDDYhsjWwiaQWrhewhtoEzo4mdmZGVk");
        private static int[] order = new int[] { 8,8,10,6,10,13,6,10,12,10,10,11,12,13,14 };
        private static int key = 101;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif

#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Y4eBcJDeI72bvACIfT8dqR/kTpXBQkxDc8FCSUHBQkJD8WVz230LMQSeHL0NmsE5HXiC9O9D/beWYR2czFTJDFYnbjH5MY8b7oj2kd2LgjbwcHmy99YSmryxS87nzrHaqqxrgOEd3Em7BIwUzmfsy4Z/3vF88ynR6+VCKZqOQEUMvSJW5UQ9BX0uvGfJyIzFSViiILUFuPMFUHCw5aXC2fe2SHr2cuG9xIQB2u09I1a8Zw/CncpVmoAI8KEjab8NRWXPqWmiMBvnc9pHlMjYzC9uyZjiHRNlMsNBrTcIlyEhUV1e8IN0uO5BXnj9c6nkc8FCYXNORUppxQvFtE5CQkJGQ0DzpnaKIo3zOGxMRJfejkwJcdjh10zHXS5LhmrOxEFAQkNC");
        private static int[] order = new int[] { 8,1,4,13,11,11,11,10,12,11,10,11,12,13,14 };
        private static int key = 67;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif

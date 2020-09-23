#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("aWxv7m1jbFzubWZu7m1tbIj9xWXseEe8BSv4GmWSmAfhQizKmyshE9t30f8uSH5Gq2Nx2iHwMg+kJ+x7BQoFDw0YBQMCTC0ZGAQDHgUYFV0VTA0fHxkBCR9MDQ8PCRwYDQIPCawPXxubVmtAOoe2Y01ittYfdSPZTC8tXO5tTlxhamVG6iTqm2FtbW0YBQoFDw0YCUwOFUwNAhVMHA0eGNlWwZhjYmz+Z91NekIYuVBhtw56alxjam85cX9tbZNoaVxvbW2TXHFkR2ptaWlrbm16cgQYGBwfVkNDG0BMDwkeGAUKBQ8NGAlMHAMABQ8VXH1qbzloZn9mLRwcAAlMJQIPQl1j8VGfRyVEdqSSotnVYrUycLqnURgEAx4FGBVdelx4am85aG9/YS0cXO5o11zub8/Mb25tbm5tblxhamUTLcT0lb2mCvBIB328z9eId0avc9KYH/eCvghjpxUjWLTOUpUUkwekFlzubRpcYmpvOXFjbW2TaGhvbm21WhOt6zm1y/XVXi6XtLkd8hLNPvnyFmDIK+c3uHpbX6eoYyGieAW9TA0CCEwPCR4YBQoFDw0YBQMCTBzdXDSANmhe4ATf43GyCR+TCzIJ0EIsypsrIRNkMlxzam85cU9odFx6elx4am85aG9/YS0cHAAJTD4DAxhqbzlxYmh6aHhHvAUr+BplkpgH4Q4ACUwfGA0CCA0eCEwYCR4BH0wNx88d/is/Oa3DQy3flJePHKGKzyAcAAlMLwkeGAUKBQ8NGAUDAkwtGWFqZUbqJOqbYW1taWlsb+5tbWww53XlspUnAJlrx05cboR0UpQ8Zb8ltBrzX3gJzRv4pUFub21sbc/ubUpcSGpvOWhnf3EtHBwACUwvCR4YPgkABQ0CDwlMAwJMGAQFH0wPCR5MAwpMGAQJTBgECQJMDRwcAAUPDUNc7a9qZEdqbWlpa25uXO3adu3fc/23cis8h2mBMhXoQYdazjsgOYAbG0INHBwACUIPAwFDDRwcAAkPDR4NDxgFDwlMHxgNGAkBCQIYH0JcX1o2XA5dZ1xlam85aGp/bjk/XX8CCEwPAwIIBRgFAwIfTAMKTBkfCQAJTCUCD0JdSlxIam85aGd/cS0cxLASTlmmSbm1Y7oHuM5IT32bzcA1y2llEHssOn1yGL/b509XK8+5A2QyXO5tfWpvOXFMaO5tZFzubWhcCFlPeSd5NXHf+Jua8PKjPNatNDxoan9uOT9df1x9am85aGZ/Zi0cHBwACUw+AwMYTC8tXHJ7YVxaXFhea4ARVe/nP0y/VKjd0/YjZgeTR5BZXl1YXF9aNnthX1lcXlxVXl1YXAvjZNhMm6fAQEwDHNpTbVzg2y+jRuok6pthbW1paWxcDl1nXGVqbznjH+0Mqnc3ZUP+3pQoJJwMVPJ5mVr1IEEU24Hg97CfG/eeGr4bXCOtKRJzIAc8+i3lqBgOZ3zvLetf5u2ldR6ZMWK5EzP3nklv1jnjITFhnUiOh73bHLNjKY1Lpp0BFIGL2Xt77m1samVG6iTqmw8IaW1c7Z5cRmpz6e/pd/VRK1uexfcs4kC43fx+tFFKC0zmXwabYe6jsofPQ5U/BjcIPMbmubaIkLxla1vcGRlN");
        private static int[] order = new int[] { 14,32,59,11,40,57,13,39,23,29,35,44,29,22,57,57,17,50,28,58,28,45,26,31,29,30,42,29,40,47,50,47,35,38,41,37,57,57,46,47,43,44,54,52,46,52,59,54,51,54,52,57,55,57,55,58,57,59,58,59,60 };
        private static int key = 108;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif

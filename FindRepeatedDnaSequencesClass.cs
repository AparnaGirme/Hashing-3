public class Solution {
    // TC => O(n)
    // SC => O(n)
    public IList<string> FindRepeatedDnaSequences(string s) {
        if(string.IsNullOrEmpty(s) || s.Length < 10){
            return new List<string>();
        }

        HashSet<string> set = new HashSet<string>();
        HashSet<string> result = new HashSet<string>();

        for(int i = 0; i <= s.Length - 10; i++){
            string substring = s.Substring(i, 10);
            if(set.Contains(substring)){
                result.Add(substring);
            }
            set.Add(substring);
        }
        return result.ToList();
    }
}
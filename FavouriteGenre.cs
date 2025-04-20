/*
Q 2. Given a map Map<String, List<String>> userSongs with user names as keys and a list of all the songs that the user has listened to as values.

Also given a map Map<String, List<String>> songGenres, with song genre as keys and a list of all the songs within that genre as values. The song can only belong to only one genre.

The task is to return a map Map<String, List<String>>, where the key is a user name and the value is a list of the user's favorite genre(s). Favorite genre is the most listened to genre. A user can have more than one favorite genre if he/she has listened to the same number of songs per each of the genres.

Example 1:

Input:
userSongs = {
  "David": ["song1", "song2", "song3", "song4", "song8"],
  "Emma": ["song5", "song6", "song7"]
},
songGenres = {
  "Rock":  ["song1", "song3"],
  "Dubstep": ["song7"],
  "Techno": ["song2", "song4"],
  "Pop":  ["song5", "song6"],
  "Jazz":  ["song8", "song9"]
}

Output: {
  "David": ["Rock", "Techno"]

*/

// TC => O(n) number of songs
// SC => O(n)
class HelloWorld {
    public static Dictionary<string, List<string>> FindGenre(Dictionary<string, List<string>> userSongs, Dictionary<string, List<string>> genreSongs){
        Dictionary<string, List<string>> userGenres = new Dictionary<string, List<string>>();
        Dictionary<string, string> songGenre = new Dictionary<string, string>();
        Dictionary<string, int> frequency = new Dictionary<string, int>();
        
        foreach(var kv in genreSongs){
            foreach(var song in kv.Value){
                songGenre.Add(song, kv.Key);
            }
        }
        
        foreach(var kv in userSongs){
            foreach(var song in kv.Value){
                frequency.TryAdd(songGenre[song], 0);
                frequency[songGenre[song]]++;
            }
            
            int max = Int32.MinValue;
            
            foreach(var kv1 in frequency){
                max = Math.Max(max, kv1.Value);
            }
            
            foreach(var kv1 in frequency){
                if(kv1.Value == max){
                    userGenres.TryAdd(kv.Key, new List<string>());
                    userGenres[kv.Key].Add(kv1.Key);
                }
            }
            
            frequency.Clear();
        }
        
        return userGenres;
    }
    static void Main() {
        Dictionary<string, List<string>> userSongs = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> genreSongs = new Dictionary<string, List<string>>();
        
        userSongs.TryAdd("David", new List<string>(){"song1", "song2", "song3", "song4", "song8"});
        userSongs.TryAdd("Emma", new List<string>(){"song5", "song6", "song7"});
        
        genreSongs.TryAdd("Rock", new List<string>(){"song1", "song3"});
        genreSongs.TryAdd("Dubstep", new List<string>(){"song7"});
        genreSongs.TryAdd("Techno", new List<string>(){"song2", "song4"});
        genreSongs.TryAdd("Pop", new List<string>(){"song5", "song6"});
        genreSongs.TryAdd("Jazz", new List<string>(){"song8", "song9"});
        
        var result = FindGenre(userSongs, genreSongs);
        
        foreach(var kv in result){
            Console.WriteLine($"{kv.Key} : [{string.Join(",", kv.Value)}]");
        }
    }
}
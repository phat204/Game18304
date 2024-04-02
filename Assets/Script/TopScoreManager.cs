using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TopScoreManager : MonoBehaviour
{
    public TextMeshProUGUI top1ScoresText, top2ScoresText, top3ScoresText, top4ScoresText, top5ScoresText;
    private int HS;
    void Start()
    {
        HS = PlayerPrefs.GetInt("HighScore");
        top1ScoresText.text = "Top 1: " + HS.ToString("n0");
        
    }
    void Update() 
    {

    }
}

///////////////////////////////////////////////////////////


// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using System;

// public class TopScoreManager : MonoBehaviour
// {
//     public List<TextMeshProUGUI> topScoresTexts = new List<TextMeshProUGUI>(); // Danh sách các TextMeshProUGUI cho top điểm số
//     private List<int> topScores = new List<int>(); // Danh sách điểm số cao nhất
//     public int maxTopScores = 5; // Số lượng điểm số cao nhất muốn hiển thị

//     private int HS;

//     void Start()
//     {
//         // Load điểm số cao nhất từ PlayerPrefs
//         for (int i = 0; i < maxTopScores; i++)
//         {
//             int score = PlayerPrefs.GetInt("TopScore" + (i + 1), 0);
//             topScores.Add(score);
//             topScoresTexts[i].text = "Top " + (i + 1) + ": " + score.ToString("n0");
//         }

//         // Load điểm số cao nhất
//         HS = PlayerPrefs.GetInt("HighScore");
//     }

//     void Update()
//     {
//         // Bạn có thể thực hiện logic cập nhật điểm số ở đây
//     }

//     // Hàm thêm điểm mới vào danh sách điểm số cao nhất và cập nhật top điểm số
//     public void AddScoreAndUpdateTop(int newScore)
//     {
//         // Thêm điểm mới vào danh sách
//         topScores.Add(newScore);

//         // Sắp xếp danh sách giảm dần
//         topScores.Sort((a, b) => b.CompareTo(a));

//         // Cập nhật top điểm số
//         for (int i = 0; i < maxTopScores; i++)
//         {
//             if (i < topScores.Count)
//             {
//                 topScoresTexts[i].text = "Top " + (i + 1) + ": " + topScores[i].ToString("n0");
//                 PlayerPrefs.SetInt("TopScore" + (i + 1), topScores[i]); // Lưu điểm số vào PlayerPrefs
//             }
//         }

//         // Kiểm tra xem điểm mới có vượt qua điểm số cao nhất hiện tại không
//         if (newScore > HS)
//         {
//             HS = newScore;
//             PlayerPrefs.SetInt("HighScore", HS); // Lưu điểm số cao nhất vào PlayerPrefs
//         }
//     }
// }

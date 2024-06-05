using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;      // 싱글톤 화
    public List<Achievement> achievements;          // Achievemnt 클래스를 List로 관리

    public Text[] AchievementTexts = new Text[4];

    private void Awake()
    {
        if(instance == null)            
        {
            instance = this;
            DontDestroyOnLoad(gameObject);              // 다른 Scene에서도 적용하기 위해서 파괴 되지 않게 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void UpdateAchievementUI()
    {
        AchievementTexts[0].text = achievements[0].name;
        AchievementTexts[1].text = achievements[0].description;
        AchievementTexts[2].text = $"{achievements[0].currentProgress}/{achievements[0].goal}";
        AchievementTexts[3].text = achievements[3].isUnlocked ? "달성" : "미달성";
    }

    public void AddProgressList(string achievementName, int amount)             // 업적 진행 상황 갱신 함수
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);        // 인수에서 받아온 이름으로 업적 리스트에서 찾아서 반환
        if(achievement != null)                                                         
        {
            achievement.AddProgress(amount);                                           // 프로그래스를 증가 시킨다.
        }
    }

    public void AddAchievement(Achievement achievement)
    {
        Achievement temp = new Achievement("이름", "이름", 5);
        achievements.Add(achievement);              //List에 업적 추가
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddProgressList("도약", 1);
            UpdateAchievementUI();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreadCal : MonoBehaviour
{
    [System.Serializable]
    public struct GradePoint
    {
        public string gradeType;
        public float point;
    }
    public List<GradePoint> gradePointList = new List<GradePoint>();

    float m_average = 0f;       // 평균 점수
    public Text textAverage;
    public InputField gradeInputField;
    public void Input(string data)
    {
        string text = string.Empty;
        float sumScore = 0;
        int sumCount = 0;

        data = data.ToUpper();
        gradeInputField.text = data;

        for (int i = 0; i < data.Length; i++)
        {
            if ((data[i] >= 'A' && data[i] <= 'D'))
            {
                if ((i + 1) != data.Length && data[i + 1] == '+')
                {
                    string grade = data.Substring(i, 2);
                    GradePoint gradePoint = gradePointList.Find(x => x.gradeType.Equals(grade));
                    sumScore += gradePoint.point;
                    sumCount++;
                }
                else
                {
                    string grade = data.Substring(i, 1);
                    GradePoint gradePoint = gradePointList.Find(x => x.gradeType.Equals(grade));
                    sumScore += gradePoint.point;
                    sumCount++;

                }
            }
            else if (data[i] == 'F')
            {
                sumCount++;
            }
       
        }
        m_average = (sumScore / sumCount);
        m_average = Mathf.Round(m_average*100)*0.01f ;
        textAverage.text = m_average.ToString();
    }
}


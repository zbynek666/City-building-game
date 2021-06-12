using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public enum TypeOfNotification { kys };
    public GameObject TopBar;
    List<GameObject> actineNotifications;
    Dictionary<TypeOfNotification, GameObject> Notifications = new Dictionary<TypeOfNotification, GameObject>();
    public List<GameObject> notif;


    public static NotificationManager Instance { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        actineNotifications = new List<GameObject>();
        Notifications[TypeOfNotification.kys] = notif[0];


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowNotification(TypeOfNotification t)
    {
        GameObject g = Instantiate(Notifications[t]);
        g.GetComponent<Button>().onClick.AddListener(delegate { NotificationDestroyed(g); });
        g.transform.parent = TopBar.transform;
        g.transform.localPosition = GetNotificationPosition(actineNotifications.Count);
        actineNotifications.Add(g);

    }

    public void NotificationDestroyed(GameObject n)
    {
        actineNotifications[actineNotifications.IndexOf(n)] = null;
        Destroy(n);

        sort();
        move();
    }

    private void move()
    {
        for (int i = 0; i < actineNotifications.Count; i++)
        {
            actineNotifications[i].transform.localPosition = GetNotificationPosition(i);
        }
    }
    public void sort()
    {
        actineNotifications.RemoveAll(item => item == null);
    }

    private Vector3 GetNotificationPosition(int i)
    {
        return new Vector3(i * 50, 0, 0);
    }



}

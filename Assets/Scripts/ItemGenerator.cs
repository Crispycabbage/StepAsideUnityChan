using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;//�ePrefab�̓��ꕨ��錾�ŏ�����o�Ă��Ă���킯�ł͖����̂Œ��ڃC���X�y�N�^�œ����H
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    private float switchpoint = 0f;
    private float placementpoint = 45f;
    private float interval = 15f;



    private GameObject unitychan;//unity�����̓��ꕨ���쐬

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.switchpoint = this.startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //���̋������ƂɃA�C�e���𐶐�
        if (this.goalPos > switchpoint && unitychan.transform.position.z+this.placementpoint >=  this.switchpoint)
            //�X�C�b�`�|�C���g�{�������E���S�[�����O�A�X�C�b�`�|�C���g�����j�e�B�����̈ʒu�{�������E���̎�
        {
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.switchpoint);
                }
            }
            else
            {

                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.switchpoint+ offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.switchpoint+ offsetZ);
                    }
                }
            }
            this.switchpoint += this.interval;

        }
    }
}
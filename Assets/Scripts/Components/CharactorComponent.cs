using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace BehaviorTreeAIExample
{
    public class CharactorComponent : BehaviourTreeExampleBehaviour
    {
        public Charactor Instance { get; private set; }
        public Subject<ICharactorAction> ActionStream;

        public void Init(Charactor instance)
        {
            Instance = instance;
            ActionStream = new Subject<ICharactorAction>();

            // Foodと接触したら捕食
            this.OnCollisionEnter2DAsObservable()
                .Where(collider => collider.gameObject.tag == "Food")
                .Subscribe(collider => Instance.Eat(collider.gameObject.GetComponent<FoodComponent>().Instance))
                .AddTo(gameObject);

            // 毎フレームごとのイベント
            this.UpdateAsObservable()
                .Subscribe(_ => {
                    Instance.Tictac();
                    Think();
                })
                .AddTo(gameObject);

            Instance.IsDead
                    .Where(_ => Instance.IsDead.Value)
                    .Subscribe(_ => Destroy(gameObject));

            // 行動イベントの監視。
            ActionStream.Where(_ => !Instance.IsDead.Value)
                        .Subscribe(action => Act(action));
        }

        void Think()
        {
            // 世界を知覚する。
            // Foodがどこにあるか知覚
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
            var foodPositionList = new List<Position>();
            for (var i = 0; i < foods.Length; i++)
                foodPositionList.Add(new Position() { X = foods[i].GetComponent<Transform>().position.x, Y = foods[i].GetComponent<Transform>().position.y });

            var myPosition = new Position() { X = gameObject.GetComponent<Transform>().position.x, Y = gameObject.GetComponent<Transform>().position.y };

            // 知覚した世界と自分の状態をもとに考える/動く
            var root = new BehaviorTreeSelector();
            root.Add(new BehaviorTreeSequence().Add(new MoveTask(myPosition, foodPositionList, ActionStream)));
            root.Act();
        }

        void Act(ICharactorAction action)
        {
            switch (action.GetType().ToString())
            {
                case "BehaviorTreeAIExample.MoveAction":
                    MoveAction move = action as MoveAction;
                    transform.position += new Vector3(move.X, move.Y);
                    break;
            }
        }
    }
}
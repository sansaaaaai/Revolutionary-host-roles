# Town Of Host
![TownOfHost-Title](https://user-images.githubusercontent.com/51523918/147845737-440bc415-0d0f-42eb-b1d4-6aab36937bd4.jpg)

## modについて

このmodは非公式のものであり、このmodの開発に関してAmong Usの開発元である"Innersloth"は一切関与していません。<br>
このmodの問題などに関して公式に問い合わせないでください。<br>

## 特徴

このmodはホスト(部屋主)のクライアントに導入するだけで動作し、他のクライアントのmodの導入/未導入及び端末の種類に関係なく動作します。<br>
また、カスタムサーバーを利用したmodと違い、URLやファイル編集などによるサーバー追加も不要なため、ホスト以外のプレイヤーはただTown Of Hostを導入したホストの部屋に参加するだけで追加役職を楽しめます。<br>

しかし、公式追加役職の科学者・エンジニアを置き換える仕組みで役職追加を行っているため、以下の制限が発生することにご注意ください。<br>

- 置き換え先役職が同じ追加役職・置き換え先となっている役職は同時に導入することができない。
- 置き換え先が異なる役職や科学者・エンジニア以外の追加役職は同時に導入することができる。
- ホストが途中で抜けるなどしてホストが変更された場合、追加役職に関する処理が正常に動作しない可能性がある。
- 特殊役職を使った場合、その特殊役職の設定を書き換える。(例：ベントクールダウン0・科学者のバイタル使用不可など)

なお、ホスト以外のプレイヤーが入れた状態でプレイすると、以下のような表示の変化が行われます。<br>

- 特殊役職独自の開始画面
- インポスター勝利時に勝者にMadmateを追加
- Jester/Terrorist勝利時に勝者が正常に勝者として表示される

なお、modを導入していないプレイヤーが特殊役職を得た場合、科学者・エンジニアとしか表示されないので、試合開始前に役職の解説をするようお願いします。<br>

## 設定変更画面
注：コマンドによる設定変更は残っていますが、今後サポートされることはなく、コマンド追加の予定もありません。<br>
ロビーでTabキーを押すと、部屋設定のテキストが設定画面に変化します。<br>
操作方法は以下の通りです。<br>
| キー | 動作 |
| :---: | ---- |
| Tab | 設定画面表示/非表示 |
| 十字キー上 | カーソルを上に移動 |
| 十字キー下 | カーソルを下に移動 |
| 十字キー右 | 選択中の項目を実行 |
| 十字キー左 | 一つ戻る |

## 役職

### Jester/てるてる

陣営：単独<br>
置き換え先：科学者<br>
勝利条件：投票で追放される<br>

Jesterはタスクを持たず、クルー陣営にもインポスター陣営にも属さない第三陣営として動く役職です。<br>
Jesterが勝利する方法はただ一つ。投票で追放されることです。<br>
Jesterが追放された場合、クルーとインポスターは敗北となり、追放されたJesterのみの勝利となります。<br>
キルされたり、追放されないままタスクやインポスター全滅で試合が終わった場合、Jesterは敗北となります。<br>
バイタルは見れません。

### Terrorist/テロリスト

陣営：第三<br>
置き換え先：エンジニア<br>
勝利条件：タスクをすべて完了した状態で何らかの要因で死ぬ<br>

Terroristは第三陣営ですが、タスクを持っています。<br>
タスクをすべて完了させてから何らかの要因で死亡すると単独勝利となります。<br>
死因はキル・投票のどちらでも単独勝利となります。<br>
タスクを完了させないまま死んだり、タスクを完了させても死なないまま試合が終わると敗北となります。<br>
Terroristのタスクはクルーのタスク数にカウントされず、Terrorist以外のすべてのクルーがタスクを終わらせるとクルーのタスク勝利となります。<br>
また、ベントが使えます<br>

### Sidekick/相棒

陣営：インポスター<br>
置き換え先：シェイプシフター<br>

Sidekickはインポスターとして判定され、ベントとサボタージュに加え変身もできます。<br>
しかし、初期状態でキルはできません。<br>
Sidekickではないインポスターが全滅したとき、すべてのSidekickのキル能力が解禁されます。<br>
キル能力解禁後のSidekickも変身が可能です。<br>

### Vampire/吸血鬼

陣営：インポスター<br>
置き換え先：インポスター<br>

Vampireは、遅延キルが可能なインポスターです。<br>
キルを発動してから10秒後にキル対象がテレポートなしで死にます。<br>
しかし、対象がBaitだった場合はVampireの能力が発動せず、普通にキルしてしまいます。<br>
キル発動からキルまでの間に会議が発生した場合、会議発生の瞬間に対象が死にます。<br>
対象が死んだとき、Vampire自身がmodを導入している場合のみVampireにのみ聞こえるキルの効果音が鳴ります。<br>
対象がタスクを終えたTerroristだった場合、実際に対象が死んでからTerroristが勝利します。<br>

### Madmate/狂人

陣営：インポスター<br>
置き換え先：エンジニア<br>

Madmateはタスクを持たず、キルもサボタージュもできませんが、インポスターの味方をする役職です。<br>
しかし、ベントへの出入りと移動が可能です。<br>
また、Madmateはインポスターを知らず、インポスターもMadmateを知らないため、インポスターが間違えてMadmateをキルしてしまう場合もあります。<br>

### Bait/ベイト

陣営：クルー<br>
置き換え先：科学者<br>

Baitは通常のクルーと同様にタスクを持ち、勝利条件も同じです。<br>
しかし、Baitがキルされたとき、Baitをキルしたインポスターに強制的にセルフレポートをさせることができます。<br>
バイタルを見ることはできません。<br>

## 参考など

Baitの役職とmodの作り方の参考：https://github.com/Eisbison/TheOtherRoles<br>
Jester(てるてる)とMadmateの役職：https://au.libhalt.net<br>



作者のTwitter：https://twitter.com/XenonBottle

# Gauss-Jordan-Elimination

以高斯-約當法 求反矩陣

參考自以下演算法

https://ocw.chu.edu.tw/pluginfile.php/788/mod_resource/content/46/Summary_192.pdf

但有個不同的地方在於，我並非先建立下三角矩陣再反向疊代，而是直接將原矩陣轉化為上下三角矩陣再把每一列除以係數。

注意：為了簡化流程，此程式並未考慮行列式值為零(即不存在反矩陣)，及原方陣之主對角線上有任何元素為0的情況。

Demo :

![Snipaste_2022-08-21_04-14-17](https://user-images.githubusercontent.com/103472129/185764621-9d92bb99-e019-41f3-83ff-644361ae1b05.png)

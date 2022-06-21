#  4.10 Централизованный мониторинг Grafana
Первым делом нужно поднять Grafana на второй тачке, где нет прометеуса.
```
docker run --rm -d --name=grafana --network="host" grafana/grafana-oss
```
Дальше зайти в само приложение на 3000ом порту.
![](https://i.imgur.com/da4oSIM.png)
Креды admin:admin
Добавляем прометеус в конфигурации
![](https://i.imgur.com/ZLcUfH8.png)
![](https://i.imgur.com/WgOUVSB.png)
Далее импортируем шаблон [node_exporterFull](https://grafana.com/grafana/dashboards/1860)
![](https://i.imgur.com/p4Ihsn4.png)

Дашборд готов:
![](https://i.imgur.com/igcXJ4N.png)

Далее создаем алерт, chat_id и API_token я закинул, теперь правила для алерта:
![](https://i.imgur.com/6FwHBMv.png)
Указываем лейбл:
![](https://i.imgur.com/WW9zci1.png)

Указываем канал передачи алерта для моего лейбла:
![](https://i.imgur.com/yIEqhSC.png)

Создал второй алерт, положил в ту же папку, дал тот же лейбл, но настроил для второй тачки:
![](https://i.imgur.com/SX2L4Vk.png)
![](https://i.imgur.com/0TLv29r.png)

Все готово, можно пробовать. Для этого создам большой файл:
```
truncate -s "<size>" test.txt - не работает
fallocate -l "<size>" test.txt
```
![](https://i.imgur.com/YKVvmvN.png)
На тачке занято 12%, значит мне нужно создать файл на 58%, а значит на 17.4G

![Uploading file..._chiub5x01]()

Теперь ждем алерта:
![](https://i.imgur.com/TXkxpEV.png)

На второй тачке:
![](https://i.imgur.com/zHQsHPv.png)
На тачке занято 43%, а значит мне нужно создать файл на 27%, получается 
4,05G
![](https://i.imgur.com/BYpzWVf.png)

Теперь ждем алерта:
![](https://i.imgur.com/QJ0rOUn.png)
В алерте также отображается два инстанса, поскольку они оба в статусе firing.

# Промежуточная аттестация 1

Скрипт clean.sh

```
#!/bin/bash

PROCENT=$(df -h | grep "/dev/vda2" | awk {'print $5'}) # Команда выводит процент занятого места в корневой партиции
PROCENT=${PROCENT::-1} # Команда отрезает последий символ, в нашем случае символ '%'
if [[ $PROCENT -gt 60 ]]  # Условие, где если процент занятого места в корневой партиции больше 60, то делаем следующие действия:
then
	echo "less than 60% free space. Currently used $PROCENT %" # Оповещаем о ситуации, все это будет в логах
	sudo truncate -s 0 /var/log/syslog # Чистим но не удаляем файл syslog
	sudo rm -f /var/log/syslog.* # Удаляем все файлы syslog.*
	sudo apt clean # Чистим кэш apt
elif [[ $PROCENT -lt 60 ]] # Условие если процент занятого места в корневой партиции меньше 60:
then
	echo "More than 60% free space in the root partition. Currently used $PROCENT %" # Уведомляем что места достаточно
else
	echo "ERROR. Oops, something went wrong" # Ну и на всякий случай если что то пойдет не так
fi
```
Далее настраиваем запуск скрипта каждые 10 минут в cron. Добавил я запись в crontab для root пользователя, вот файл clean_sh_cron, который содержит файл конфигруации cron для root:
```
# Edit this file to introduce tasks to be run by cron.
# 
# Each task to run has to be defined through a single line
# indicating with different fields when the task will be run
# and what command to run for the task
# 
# To define the time you can provide concrete values for
# minute (m), hour (h), day of month (dom), month (mon),
# and day of week (dow) or use '*' in these fields (for 'any').
# 
# Notice that tasks will be started based on the cron's system
# daemon's notion of time and timezones.
# 
# Output of the crontab jobs (including errors) is sent through
# email to the user the crontab file belongs to (unless redirected).
# 
# For example, you can run a backup of all your user accounts
# at 5 a.m every week with:
# 0 5 * * 1 tar -zcf /var/backups/home.tgz /home/
# 
# For more information see the manual pages of crontab(5) and cron(8)
# 
# m h  dom mon dow   command
*/10 * * * * /home/xokage/5/clean.sh >> /var/log/clean_sh.log 2>&1
```

Далее настроим logrotate. 

Я создал файл конфигурации /etc/logrotate.d/clean.sh Так он выглядит:

```
/var/log/clean_sh.log {
daily
rotate 3
size 50M
dateext
compress
delaycompress
}
```

Проверим в режиме дэбага:

![](https://i.imgur.com/AwUgLdD.png)

Все работает.

Поменял местами ключи в Условном выражении:

![](https://i.imgur.com/JIYaEN0.png)

Чтобы проверить обратный случай, все отработало. В логах запись есть, syslog файлы удалены, syslog файл чистый
Было:

![](https://i.imgur.com/CZ4YUGp.png)

Стало:

![](https://i.imgur.com/VYnRBiu.png)

Логи тоже создаются:

![](https://i.imgur.com/jVyYKFK.png)

Остается запаковать необходимые артифакты командой:

sudo tar -czvf clean_sh.tar.gz /home/xokage/5/* /var/log/clean_sh.log /etc/logrotate.d/clean.conf

Далее через scp перекидываем к себе на хост.
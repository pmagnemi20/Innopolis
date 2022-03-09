#!/bin/bash

#DZ №4

echo -e "First result: $(( $(cat $1) ))\nSecond result: $(( $(cat $2) ))"
if [[ $(( $(cat $1) )) -ge $(( $(cat $2) )) ]]
then
	echo $(( $(cat $1) ))
else
	echo $(( $(cat $2) ))
fi

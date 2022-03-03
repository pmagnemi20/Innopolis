#!/bin/bash

#DZ №4

echo -e "First result: $(( $(cat 1.txt) ))\nSecond result: $(( $(cat 2.txt) ))"
if [[ $(( $(cat 1.txt) )) -ge $(( $(cat 2.txt) )) ]]
then
	echo "Greater: $(( $(cat 1.txt) ))"
else
	echo "Greater: $(( $(cat 2.txt) ))"
fi

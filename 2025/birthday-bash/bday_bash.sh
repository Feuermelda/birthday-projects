#!/bin/bash

trap 'tput sgr0; tput op' EXIT

mpg123 -q Happy_Birthday.mp3 &

echo -e "\n$(tput setab 6)$(tput setaf 4)HAPPY BIRTHDAY, FEUERMELDA!$(tput sgr0)\n"

cake=$(cat << EOF
\033[33m     i i i i i\033[0m
   \033[35;1;47m|:H:a:p:p:y:|\033[0m
 \033[35;0m__\033[35;47m|___________|\033[35;0m__\033[0m
\033[34;47m|^^^^^^^^^^^^^^^^^|\033[0m
\033[35;1;47m|:B:i:r:t:h:d:a:y:|\033[0m
\033[35;1;47m|      Melda      |\033[0m
\033[30;47m~~~~~~~~~~~~~~~~~~~\033[0m
EOF
)
echo -e "$cake"
sleep 1

echo -e "\nNow summoning 24 birthday eels..."
echo ""
sleep 3

eel_right="_--_--_--_O"
eel_left="O_--_--_--_"
eel_count=24

for((i=1; i<=eel_count; i++)); do

if (( RANDOM % 2 == 0 )); then
eel="$eel_right"
else
eel="$eel_left"
fi

spaces=$(shuf -i 0-30 -n 1)
printf "%*s%s\n" "$spaces" "" "$eel"
sleep 0.1
done

echo ""
echo -e "That's one eel for every year you've rocked this world!\n"

birthdate=$(date -d "2001-06-30 07:23:00" +%s)
now=$(date +%s)

age_seconds=$((now - birthdate))

years=$(( age_seconds / (365*86400) ))

recent_birthday=$(date -d "$((2001 + years))-06-30 07:23:00" +%s)

extra_seconds=$(( now - recent_birthday ))
extra_days=$(( extra_seconds / 86400 ))

current_year=$(date +%Y)
birthday_this_year=$(date -d "$current_year-06-30 07:23:00" +%s)

if (( now >= birthday_this_year )); then
next_year=$((current_year + 1))
birthday=$(date -d "$next_year-06-30 07:23:00" +%s)
else
birthday=$birthday_this_year
fi

seconds_left=$((birthday - now))
days=$((seconds_left / 86400))
hours=$(( (seconds_left % 86400) / 3600 ))
minutes=$(( (seconds_left % 3600) / 60 ))
seconds=$((seconds_left % 60))

sleep 1

echo -e "\nCountdown to your next Eel-Day:"
sleep 1
printf "%d days, %02d hours, %02d minutes, %02d seconds\n" "$days" "$hours" "$minutes" "$seconds"

sleep 1
echo -e "\nCurrent Age:"
sleep 1
echo "$years years and $extra_days days"

tput sgr0
tput op
tput init

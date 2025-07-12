import subprocess
from pathlib import Path
import shutil
import time

VIRUS_NAME = "bday_virus.py"
PAYLOAD_TEXT = "Happy Birthday!\n"

# Suppress both stdout and stderr
subprocess.Popen(["mpg123", "Happy_Birthday.mp3"],
               stdout=subprocess.DEVNULL,
               stderr=subprocess.DEVNULL
)
time.sleep(1)

print("Executing Happy Birthday Virus...")
time.sleep(4)

targets = ["melda", "bene", "valerie"]

this_file = Path(__file__)

for target in targets:
    target_path = Path(target)
    if target_path.is_dir():

        virus_copy = target_path / VIRUS_NAME
        message_file = target_path / "congratulations.txt"

        shutil.copy(this_file, virus_copy)
        message_file.write_text(f"{PAYLOAD_TEXT}🎂🎉🥳🎈✨🎁\nBirthday Wishes to you, {target.capitalize()}!\n")

print("Happy Birthday Virus executed.")
time.sleep(1)
print(f"Now deleting self: {this_file.name}...")
time.sleep(2)

try:
    this_file.unlink()
    print("Self-deletion complete.\nHappy Birthday!")
except Exception as e:
    print(f"Failed to delete self: {e}")

time.sleep(1)

subprocess.run(["tput", "init"])
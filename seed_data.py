import requests
import json
import random
import string
import argparse
letters = string.ascii_lowercase

def generate():
    sentence = ''
    for x in range(5):
        for x in range(1000):
            sentence = ''.join(random.choice(letters) for i in range(1000))
        sentence += ' \n\n\n '

    response = requests.put(
        url='http://localhost:5000/notes',
        json={
            "note": sentence
        }
    )

    print(json.dumps(response.json().get('noteId')))

def main():
    args = argparse.ArgumentParser()

    args.add_argument(
        nargs="?",
        type=int,
        dest="total"
    )

    parsed = args.parse_args()
    if parsed.total:
        for x in range(parsed.total):
            generate()
    else:
        print('you need to specify an amount to generate')

if __name__ == '__main__':
    main()
import json

from voivodeship import Voivodeship


class DeserializeJson:

    def __init__(self, filename):
        temp_data = open(filename, encoding="utf8")
        self.data = json.load(temp_data)

    # przykładowe statystyki.
    def some_stats(self):
        example_stat = 0

        for dep in self.data:
            if dep['typ_JST'] == 'GM' and dep['Województwo'] == 'dolnośląskie':
                example_stat += 1

        print('Liczba urzędów miejskich w województwie dolnośląskim:', str(example_stat))

    def number_of_individual_offices_in_each_voivodeship(self):
        voivodeship_names = set()
        for dep in self.data:
            voivodeship_name = dep['Województwo'].strip()
            voivodeship_names.add(voivodeship_name)

        voivodeships = dict()
        for voivodeship_name in voivodeship_names:
            voivodeships[voivodeship_name] = Voivodeship(voivodeship_name)

        for dep in self.data:
            jst_type = dep['typ_JST'].strip()
            voivodeship_name = dep['Województwo'].strip()

            match jst_type:
                case 'GW':
                    voivodeships[voivodeship_name].GW += 1
                case 'GMW':
                    voivodeships[voivodeship_name].GMW += 1
                case 'MNP':
                    voivodeships[voivodeship_name].MNP += 1
                case 'dzielnica':
                    voivodeships[voivodeship_name].dzielnica += 1
                case 'W':
                    voivodeships[voivodeship_name].W += 1
                case 'GM':
                    voivodeships[voivodeship_name].GM += 1
                case 'P':
                    voivodeships[voivodeship_name].P += 1

        for voivodeship in voivodeships.values():
            print(voivodeship)

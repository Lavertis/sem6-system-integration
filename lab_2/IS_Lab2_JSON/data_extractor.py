class DataExtractor:
    @staticmethod
    def extract(deserialized_data):
        lst = []

        for dep in deserialized_data:
            lst.append({
                "Kod_TERYT": dep['Kod_TERYT'],
                "Województwo": dep['Województwo'],
                "Powiat": dep['Powiat'],
                "typ_JST": dep['typ_JST'],
                "nazwa_urzędu_JST": dep['nazwa_urzędu_JST'],
                "miejscowość": dep['miejscowość'],
                "telefon_z_numerem_kierunkowym": f'{dep["telefon kierunkowy"]}-{dep["telefon"]}'
            })
        return lst

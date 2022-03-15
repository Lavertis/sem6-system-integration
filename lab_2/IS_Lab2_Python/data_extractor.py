class DataExtractor:
    @staticmethod
    def extract_from_json(deserialized_data):
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

    @staticmethod
    def extract_from_xml(items):
        lst = []

        for dep in items:
            lst.append({
                "Kod_TERYT": dep.find("Kod_TERYT").text,
                "Województwo": dep.find("Województwo").text,
                "Powiat": dep.find("Powiat").text,
                "typ_JST": dep.find("typ_JST").text,
                "nazwa_urzędu_JST": dep.find("nazwa_urzędu_JST").text,
                "miejscowość": dep.find("miejscowość").text,
                "telefon_z_numerem_kierunkowym": f'{dep.find("telefon_kierunkowy").text}-{dep.find("telefon").text}'
            })
        return lst

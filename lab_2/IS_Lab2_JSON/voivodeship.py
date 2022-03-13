class Voivodeship:
    def __init__(self, name):
        self.name = name
        self.GW = 0
        self.GMW = 0
        self.MNP = 0
        self.dzielnica = 0
        self.W = 0
        self.GM = 0
        self.P = 0

    def __str__(self) -> str:
        s = f'Voivodeship[name: {self.name}, GW: {self.GW}, GWM: {self.GMW}, MNP: {self.MNP}, ' \
            f'dzielnica: {self.dzielnica}, W: {self.W}, GM: {self.GM}, P: {self.P}]'
        return s

    def __repr__(self) -> str:
        s = f'Voivodeship{{name: {self.name}, GW: {self.GW}, GWM: {self.GMW}, MNP: {self.MNP}, ' \
            f'dzielnica: {self.dzielnica}, W: {self.W}, GM: {self.GM}, P: {self.P}}}'
        return s

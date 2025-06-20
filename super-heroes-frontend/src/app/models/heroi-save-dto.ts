export interface HeroiSaveDTO {
  id?: number;
  nome: string;
  nomeHeroi: string;
  superpoderesIds: number[];
  dataNascimento: string; // "yyyy-MM-dd"
  altura: number;
  peso: number;
}
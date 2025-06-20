import { SuperPoder } from './super-poder'; // ajuste o caminho se necessário

export interface Heroi {
  id: number;
  nome: string;
  nomeHeroi: string;
  superpoderes: SuperPoder[]; // agora é uma lista de objetos
  dataNascimento: Date | null;
  altura: number;
  peso: number;
}
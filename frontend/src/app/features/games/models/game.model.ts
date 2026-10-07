export interface Game {
    id: number;
    externalId: string;
    title: string;
    description?: string;
    publisher?: string;
    genre?: string;
    imageUrl?: string;
    backgroundImage?: string;
    metacriticScore?: number;
}
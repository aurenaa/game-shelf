export interface RawgGame {
  id: number;                    
  name: string;                 
  description_raw?: string;      
  background_image?: string;     
  released?: string;             
  metacritic?: number;           
  genres?: RawgGenre[];          
  publishers?: RawgPublisher[];  
}

export interface RawgGenre {
  name: string;
}

export interface RawgPublisher {
  name: string;
}

export interface RawgSearchResponse {
  count: number;
  results: RawgGame[];
}
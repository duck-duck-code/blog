import { ApiProperty } from '@nestjs/swagger';
import { IsUUID } from 'class-validator';
import { ArticleBody } from './ArticleBody';

export class ArticleDto extends ArticleBody {
  @ApiProperty()
  @IsUUID()
  id: string;
}

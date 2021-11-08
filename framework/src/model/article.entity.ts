import { Entity, Column, UpdateDateColumn } from 'typeorm';
import { BaseEntity } from './base.entity';

@Entity({ name: 'article' })
export class Article extends BaseEntity {
  @Column({ type: 'varchar', length: 300 })
  title: string;

  @Column({ type: 'varchar', length: 300 })
  content: string;

  @UpdateDateColumn({ type: 'timestamptz', default: () => 'CURRENT_TIMESTAMP' })
  lastChangedDateTime: Date;

  @Column({ type: 'varchar', length: 300 })
  createdBy: string;

  @Column({ type: 'varchar', length: 300 })
  lastChangedBy: string;
}

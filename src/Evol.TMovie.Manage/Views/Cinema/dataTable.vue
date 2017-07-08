<div id="cinema-table" class="box">
    <div class="box-header">
        <h3 class="box-title">影院</h3>
    </div>
    <!-- /.box-header -->
    <div class="box-body">
        <table id="data-table1" class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>编号</th>
                    <th>名称</th>
                    <th>地址</th>
                    <th>创建时间</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody v-for="item in models">
                
                <tr>
                    <td>{{ item.id }}</td>
                    <td>{{ item.name }}</td>
                    <td>{{ item.address }}</td>
                    <td> {{ item.createTime }}</td>
                    <td></td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th>编号</th>
                    <th>名称</th>
                    <th>地址</th>
                    <th>创建时间</th>
                    <th>操作</th>
                </tr>
            </tfoot>
        </table>
    </div>
    <!-- /.box-body -->
</div>